using System;
using CityBuilder.Scripts.Interface;
using DG.Tweening;
using UnityEngine;

namespace CityBuilder.Scripts
{
    public class DropTarget : TileView, IDropTarget, IDraggingListener
    {
        
        [SerializeField] private GoalView goalView;
        private bool isAnimationPlay;
        
        private void Awake()
        {
            CanDrop = true;
        }

        public bool CanDrop { get; private set; }
        public void DragEnter(IDraggable draggable)
        {
            goalView.Renderer.material.color = Color.green;
        }

        public void DragExit(IDraggable draggable)
        {
            goalView.Renderer.material.color = Color.white;
        }

        public void Drop(IDraggable draggable)
        {
            draggable.Transform.position = transform.position;
            draggable.IsDraggable = false;
            CanDrop = false;
            
        }

        public Transform Transform => transform;

        public void DragStarted(IDraggable draggable)
        {
            if (CanDrop)
            {
                goalView.gameObject.SetActive(true);
                isAnimationPlay = true;
                GoalViewAnimation();
            }
        }

        public void DragFinished(IDraggable draggable)
        {
            goalView.gameObject.SetActive(false);
            isAnimationPlay = false;
            
        }

        private void GoalViewAnimation()
        {
            if (isAnimationPlay)
            {
                var s = DOTween.Sequence();
                s.Append(goalView.transform.DOMoveY(.5f, .5f));
                s.Append(goalView.transform.DOMoveY(.25f, .5f));
                s.OnComplete(GoalViewAnimation);
            }
        }
    }
}