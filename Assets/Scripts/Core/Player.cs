using UnityEngine;
using UnityEngine.Animations.Rigging;

namespace TestLavaProject.Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Collider _collider;
        [SerializeField] private PlayerMovement _playerMovement;
        public PlayerMovement PlayerMovement => _playerMovement;

        [SerializeField] private PlayerShooting _playerShooting;
        [SerializeField] private RigBuilder _rigBuilder;
        public RigBuilder RigBuilder => _rigBuilder;
        
        public PlayerShooting PlayerShooting => _playerShooting;
        
        public Vector3 CenterPosition => _collider.bounds.center;

        private void Update()
        {
            _playerMovement.TryMove();
            _playerShooting.TryShoot(Time.deltaTime);
        }
    }
}