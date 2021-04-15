using System;
using UnityEngine;

namespace TestLavaProject.Core
{
    public abstract class GameStateLogic
    {
        protected readonly Player _player;
        protected readonly Enemy _enemy;
        protected bool _isReadyForChanging;

        protected GameStateLogic(Player player, Enemy enemy)
        {
            _player = player;
            _enemy = enemy;
        }
        
        public abstract GameState State { get;}
        public Action<GameState> ReadyForChanging;
        
        public abstract void Start();

        public abstract void Update();

        public abstract void End();
    }
}