using System;
using TestLavaProject.Managers;
using UnityEngine;
using UnityEngine.AI;

namespace TestLavaProject.Core
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _navMeshAgent;
        [SerializeField] private Animator _animator;

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
            _navMeshAgent.speed = DataManager.GameSettings.PlayerSpeed * Mathf.Clamp01(speedFraction);
            _navMeshAgent.isStopped = false;
        }

        private void FixedUpdate()
        {
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            var velocity = _navMeshAgent.velocity;
            var localVelocity = transform.InverseTransformDirection(velocity);
            var speed = localVelocity.z;
            _animator.SetFloat("ForwardSpeed", speed);
        }
    }
}