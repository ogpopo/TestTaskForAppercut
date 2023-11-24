using Scripts.Abstarct;
using UnityEngine;

namespace Resourses.Player
{
    public class PlayerView : MonoBehaviour, IView
    {
        public void OnMove(Vector3 newPosition)
        {
            transform.position = newPosition;
        }
    }
}