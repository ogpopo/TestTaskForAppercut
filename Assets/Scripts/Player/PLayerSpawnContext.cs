using UnityEngine;

namespace Resourses.Player
{
    public class PLayerSpawnContext
    {
        public Vector3 Position { get; private set; }
        public float Speed { get; private set; }

        public PLayerSpawnContext(Vector3 position, float speed)
        {
            Position = position;
            Speed = speed;
        }
    }
}