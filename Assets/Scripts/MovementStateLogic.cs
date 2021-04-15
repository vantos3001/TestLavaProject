using System;
using UnityEngine;

namespace TestLavaProject.Core
{
    public class MovementStateLogic : GameStateLogic
    {
        private const float MaxShootAreaDistance = 10f;

        public override GameState State => GameState.Movement;

        public MovementStateLogic(Player player, Enemy enemy) : base(player, enemy)
        {
        }

        public override void Start()
        {
            _player.CanMove = true;
            _isReadyForChanging = false;
        }

        public override void Update()
        {
            TryNotifyReadyForChanging();
        }

        private void TryNotifyReadyForChanging()
        {
            if (_isReadyForChanging)
            {
                return;
            }

            if (!IsShootArea(_player.transform.position) ||
                !IsDetectEnemy(_player.CenterPosition, _enemy.CenterPosition))
            {
                return;
            }

            NotifyReadyForChanging();
        }

        private void NotifyReadyForChanging()
        {
            _isReadyForChanging = true;
            ReadyForChanging?.Invoke(GameState.Shooting);
        }

        private bool IsDetectEnemy(Vector3 startPosition, Vector3 endPosition)
        {
            var diff = endPosition - startPosition;

            var direction = diff.normalized;

            var distance = diff.magnitude;

            Debug.DrawLine(startPosition, endPosition, Color.red);

            if (!Physics.Raycast(startPosition, direction, out var hit, distance))
            {
                return false;
            }

            Debug.Log("CheckLayer");

            return hit.transform.gameObject.layer == Utils.Utils.EnemyLayer;
        }

        private bool IsShootArea(Vector3 startPosition)
        {
            return Physics.Raycast(startPosition, Vector3.down, MaxShootAreaDistance, Utils.Utils.ShootAreaLayerMask);
        }

        public override void End()
        {
            _player.CanMove = false;
        }
    }
}