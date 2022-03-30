using System;
using DG.Tweening;
using UnityEngine;

namespace Runner3D.Scripts
{
    [Serializable]
    public abstract class UIView : MonoBehaviour
    {
        public string Name;

        public abstract string ViewName { get; }
        
        
        protected void Initialize()
        {
            transform.localScale = Vector3.zero;
        }
        
        public Tweener Show()
        {
            gameObject.SetActive(true);
            return transform.DOScale(1f, .5f);
        }

        public Tweener Hide()
        {
            transform.DOScale(0f,.5f);
            var tweener = transform.DOScale(0f, .5f);
            tweener.onComplete += () => gameObject.SetActive(false);

            return tweener;
        }
    }
}