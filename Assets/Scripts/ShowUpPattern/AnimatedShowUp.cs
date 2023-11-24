using DG.Tweening;
using Scripts.Abstarct;
using UnityEngine;

namespace ShowUpPattern
{
    public class AnimatedShowUp : IShowUp
    {
        public void Show(GameObject gameObject)
        {
            gameObject.transform.localScale = Vector3.zero;
            gameObject.SetActive(true);
            gameObject.transform.DOScale(new Vector3(.6f, .6f, .6f), 0.5f);
        }
    }
}