using System;
using TestLavaProject.Managers;
using UnityEngine;

namespace TestLavaProject.Core
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;

        private ProjectileInfo _projectileInfo;

        public void Init(ProjectileInfo projectileInfo)
        {
            _projectileInfo = projectileInfo;
            _projectileInfo.CurrentLiveTime = DataManager.GameSettings.MaxProjectileLiveTime;

            transform.position = _projectileInfo.StartPosition;
            transform.rotation = Quaternion.LookRotation(_projectileInfo.Direction);
            
            _rigidbody.AddForce(DataManager.GameSettings.ProjectileSpeed * _projectileInfo.Direction, ForceMode.Impulse);
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

        private void OnCollisionEnter(Collision other)
        {
            Destroy(gameObject);
        }
    }
}