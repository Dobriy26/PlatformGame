using System;
using DG.Tweening;
using UnityEngine;

namespace CityBuilder.Scripts
{
    public class CarRoute : MonoBehaviour
    {
        [SerializeField] private PathModel path;
        [SerializeField] private float speed;

        private void Start()
        {
            transform.position = path.Ways[0].Item1;
            Go(0);
        }

        private void Go(int index)
        {
            

            var sequence = DOTween.Sequence();
            var (point1, point2) = path.Ways[index];
            var dist = Vector3.Distance(point1, point2);
            var tween = transform.DOMove(point2, dist/speed);
           
            sequence.Append(tween);
            index++;
            if (index == path.Ways.Count)
            {
                index = 0;
            }
            (point1, point2) = path.Ways[index];
            var diff = point2 - point1;
            var direction = diff.normalized;
            var quaternion = Quaternion.LookRotation(direction);
            
            sequence.Append(transform.DORotateQuaternion(quaternion, 0.9f).SetEase(Ease.Flash));
            sequence.OnComplete((() => { Go(index); }));
        }
    }
}