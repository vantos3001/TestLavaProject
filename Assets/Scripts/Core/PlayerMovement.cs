using UnityEngine;
using UnityEngine.AI;

namespace TestLavaProject.Core
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private float MaxSpeed = 10f;

        [HideInInspector] public bool CanMove;

        public void TryMove()
        {
            if (!CanMove || !Physics.Raycast(Utils.Utils.GetMouseRay(), out var hit))
            {
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                MoveTo(hit.point, 1f);
            }
        }

        private void MoveTo(Vector3 destination, float speedFraction)
        {
            _navMeshAgent.destination = destination;
            _navMeshAgent.speed = MaxSpeed * Mathf.Clamp01(speedFraction);
            _navMeshAgent.isStopped = false;
        }
    }
}