using UnityEngine;

namespace Sources.Planets
{
    public class Attractive : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;

        public Rigidbody2D Rigidbody => _rigidbody;
        public Vector2 Position => transform.position;
    }
}