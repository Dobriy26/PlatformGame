using System;
using DG.Tweening;
using UnityEngine;

namespace CityBielder.Scripts
{
    public class CarRoad : MonoBehaviour
    {
        [SerializeField] private PathModel path;
        [SerializeField] private float speed;

        private void Start()
        {
            transform.position = path.Ways[0];
        }

        private void Go(int index)
        {
            var (point1, point2) = path.Ways[index];
            var dist = Vector3.Distance(point1, point2);
            transform.DOMove(point2, dist/speed);
        }
    }
}