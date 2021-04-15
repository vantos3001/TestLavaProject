using UnityEngine;

namespace TestLavaProject.Core
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        [SerializeField] private float _maxProjectileLiveTime;
        [SerializeField] private float _speed;

        private ProjectileInfo _projectileInfo;

        public void Init(ProjectileInfo projectileInfo)
        {
            _projectileInfo = projectileInfo;
            _projectileInfo.CurrentLiveTime = _maxProjectileLiveTime;

            transform.position = _projectileInfo.StartPosition;
            
            _rigidbody.AddForce(_speed * _projectileInfo.Direction, ForceMode.Impulse);
        }

        private void FixedUpdate()
        {
            UpdateMovement(Time.fixedDeltaTime);
        }

        private void UpdateMovement(float delta)
        {
            _projectileInfo.CurrentLiveTime -= delta;

            if (_projectileInfo.CurrentLiveTime <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}