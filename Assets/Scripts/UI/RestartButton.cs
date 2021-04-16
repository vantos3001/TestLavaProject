using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace TestLavaProject.UI
{
    public class RestartButton : MonoBehaviour
    {
        [SerializeField] private Button _button;

        private void Awake()
        {
            _button.onClick.AddListener(OnRestartButton);
        }

        private void OnRestartButton()
        {
            SceneManager.LoadScene("SampleScene");
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(OnRestartButton);
        }
    }
}