using System;
using DG.Tweening;
using UnityEngine;

namespace CityBuilder.Scripts
{
    [RequireComponent(typeof(Renderer), typeof(MeshFilter))]
    public class BuildingView: MonoBehaviour
    {
        public Renderer Renderer;
        public MeshFilter MeshFilter;

        private void Start()
        {
            DoRotate();
        }

        private void DoRotate()
        {
            var rotation = transform.rotation;
            var tweenerCore = transform.DORotateQuaternion(
                Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y + 180, rotation.eulerAngles.z), 3f).SetEase(Ease.Linear);
            tweenerCore.OnComplete(DoRotate);
        }
    }
}