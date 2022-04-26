using CityBuilder.Scripts.Interface;
using DG.Tweening;
using UnityEngine;

namespace CityBuilder.Scripts
{
    public class DraggableView : MonoBehaviour, IDraggable, IDraggingListener
    {
        private bool _isDraggable;
        [SerializeField] private GameObject markerAnimation;
        private bool _isAnimationPause;
        public bool IsDraggable { get; set; } = true;
        public Transform Transform => transform;
        public void DragStarted(IDraggable draggable)
        {
            markerAnimation.SetActive(true);
            _isAnimationPause = true;
            GoalMarkerAnimation();
           // Debug.Log("DragStarted");
        }

        public void DragFinished(IDraggable draggable)
        {
            markerAnimation.SetActive(false);
            _isAnimationPause = false;
           // Debug.Log("DragFinished");
        }
    
        private void GoalMarkerAnimation()
        {
            if (_isAnimationPause)
            {
                var s = DOTween.Sequence();
                s.Append(markerAnimation.transform.DOMoveY(3f, .5f));
                s.Append(markerAnimation.transform.DOMoveY(2.6f, .5f));
                s.OnComplete(GoalMarkerAnimation);
            }
        }
    
       
    }
}
