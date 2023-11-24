using Scripts.Abstarct;
using UnityEngine;

namespace ShowUpPattern
{
    public class DefauldShowUp : IShowUp
    {
        public void Show(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }
    }
}