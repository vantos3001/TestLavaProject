using TestLavaProject.Managers;
using UnityEngine;


namespace TestLavaProject.Core
{
    public class PlayerShooting : MonoBehaviour
    {
        [HideInInspector] public bool CanShoot;

        [SerializeField] private GameObject ProjectilePrefab;

        private float _currentTime;

        private float MaxTime => 1f / DataManager.GameSettings.FireRate;

        public void TryShoot(float delta, Vector3 from)
        {
            if (!CanShoot)
            {
                return;
            }

            _currentTime += delta;

            if (_currentTime < MaxTime)
            {
                return;
            }

            if (!Physics.Raycast(Utils.Utils.GetMouseRay(), out var hit))
            {
                return;
            }

            if (!Input.GetMouseButton(0))
            {
                return;
            }

            Shoot(from, hit.point);
        }

        private void Shoot(Vector3 from, Vector3 to)
        {
            var projectile = SpawnProjectile();
            
            var projectileInfo = new ProjectileInfo();
            
            var direction = (to - from).normalized;

            projectileInfo.StartPosition = from;
            projectileInfo.Direction = direction;
            
            projectile.Init(projectileInfo);

            _currentTime = 0f;
        }

        private Projectile SpawnProjectile()
        {
            var projectileGO = Instantiate(ProjectilePrefab);

            return projectileGO.GetComponent<Projectile>();
        }
    }
}