using UnityEngine;

namespace TestLavaProject.Configs
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "Configs/GameSettings", order = 1)]
    public class GameSettings : ScriptableObject
    {
        public float FireRate = 10f;

        public float PlayerSpeed = 10f;
        
        public float MaxProjectileLiveTime = 3f;
        public float ProjectileForce = 1000f;
    }
}