using System;
using System.Collections.Generic;
using UnityEngine;

namespace TestLavaProject.Core
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Enemy _enemy;
        
        private GameStateLogic _currentStateLogic;

        private readonly Dictionary<GameState, GameStateLogic> _gameStateLogic = new Dictionary<GameState, GameStateLogic>();
        
        private void Awake()
        {
            Init();
        }

        private void Init()
        {
            _gameStateLogic.Add(GameState.Movement, new MovementStateLogic(_player, _enemy));
            _gameStateLogic.Add(GameState.Shooting, new ShootingStateLogic(_player, _enemy));

            foreach (var pair in _gameStateLogic)
            {
                pair.Value.ReadyForChanging += ChangeState;
            }
            
            SetLogic(_gameStateLogic[GameState.Movement]);
        }

        private void ChangeState(GameState state)
        {
            if (_currentStateLogic.State == state)
            {
                return;
            }

            if (!_gameStateLogic.TryGetValue(state, out var newStateLogic))
            {
                Debug.LogError("Not found gameStateLogic with state = " + state);
                return;
            }
            
            SetLogic(newStateLogic);
        }

        private void SetLogic(GameStateLogic newLogic)
        {
            _currentStateLogic?.End();
            
            _currentStateLogic = newLogic;
            _currentStateLogic.Start();
        }

        private void Update()
        {
            _currentStateLogic?.Update();
        }

        private void OnDestroy()
        {
            foreach (var pair in _gameStateLogic)
            {
                pair.Value.ReadyForChanging -= ChangeState;
            }
        }
    }
}