using UnityEngine;

namespace TestLavaProject.Core
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private Collider _collider;

        [SerializeField] private Animator _animator;

        public Vector3 CenterPosition => _collider.bounds.center;

        private bool _isDead;

        private void OnTriggerEnter(Collider other)
        {
            if (_isDead || other.GetComponent<Projectile>() == null)
            {
                return;
            }

            _isDead = true;
            _animator.enabled = false;
        }
    }
}