using TestLavaProject.Configs;
using UnityEngine;

namespace TestLavaProject.Managers
{
    public static class DataManager
    {
        private const string GameSettingsPath = "GameSettings";

        private static GameSettings _gameSettings;

        public static GameSettings GameSettings
        {
            get
            {
                if (_gameSettings == null)
                {
                    _gameSettings = Resources.Load<GameSettings>(GameSettingsPath);
                }

                return _gameSettings;
            }
        }
    }
}