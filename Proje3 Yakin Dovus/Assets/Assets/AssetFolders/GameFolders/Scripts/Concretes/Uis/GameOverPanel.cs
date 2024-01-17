using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Combats;
using UdemyProject3.Controllers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProject3.Uis
{
    public class GameOverPanel : MonoBehaviour
    {
        IHealth _playerHealth;

        [SerializeField] GameObject gameOverPanel;

        private void Start()
        {
            gameOverPanel.SetActive(false);
            _playerHealth = FindObjectOfType<PlayerController>().GetComponent<IHealth>();
        }

        private void Update()
        {
            ShowGameOverPanel();
        }
        void ShowGameOverPanel()
        {
            if (_playerHealth.IsDead)
            {
                gameOverPanel.SetActive(true);
            }
            else
            {
                gameOverPanel.SetActive(false);
            }
        }

        public void BackToMenu()
        {
            SceneManager.LoadSceneAsync("MyMenu");
        }

        public void PlayAgain()
        {
            SceneManager.LoadSceneAsync("Game");
        }

    }

   

}
