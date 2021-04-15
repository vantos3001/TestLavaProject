using UnityEngine;
using UnityEngine.AI;

namespace TestLavaProject.Core
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Collider _collider;
        [SerializeField] private float MaxSpeed = 10f;

        public bool CanMove;
        public bool CanShoot;

        public Vector3 CenterPosition => _collider.bounds.center;

        private void Update()
        {
            TryMove();
        }

        private void TryMove()
        {
            if (!CanMove || !Physics.Raycast(GetMouseRay(), out var hit)) {return;}
            
            if (Input.GetMouseButton(0))
            {
                MoveTo(hit.point, 1f);
            }
        }

        private static Ray GetMouseRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
        
        private void MoveTo(Vector3 destination, float speedFraction)
        {
            _navMeshAgent.destination = destination;
            _navMeshAgent.speed = MaxSpeed * Mathf.Clamp01(speedFraction);
            _navMeshAgent.isStopped = false;
        }
    }
}


