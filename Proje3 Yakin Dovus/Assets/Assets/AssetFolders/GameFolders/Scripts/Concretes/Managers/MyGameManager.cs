using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Enums;
using UdemyProject3.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace UdemyProject3.Managers
{
    public class MyGameManager : MonoBehaviour
    {

        public static MyGameManager Instance;
        /*public static MyGameManager Instance { get; private set; }

        //public event System.Action<SceneTypeEnum> OnSceneChanged;

        private void Awake()
        {
            Singelton();
        }
        void Singelton()
        {
            if (Instance != null)
            {
                Destroy(this);
                return;
            }

            else
            {
               //DontDestroyOnLoad(this.gameObject);
                Instance = this;
            }

        }*/
        /*public void StartGame()
        {
            StartCoroutine(StartGameAsync());
        }

        private IEnumerator StartGameAsync()
        {
            //yield return SceneManager.LoadSceneAsync("Ui");
            yield return SceneManager.LoadSceneAsync("Game");

        }

        public void ReturnMenu()
        {

        }*/
        /*private void Awake()
        {
         if(Instance==null)
            {
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
            else
            {
                Destroy(this.gameObject);
            }
        }*/

        public void SplashScrenn() // 1. iþlem bu start butonuna verilen metod da bu
        {
            StartCoroutine("SplashScreenAsycn");
        }

        private IEnumerator SplashScreenAsycn()
        {
            yield return SceneManager.LoadSceneAsync("SplashScene");
            yield return new WaitForSeconds(1);

            //StartGame();
        }



        public void QuitGame()
        {
            Debug.Log("Quit");
            Application.Quit();

        }


    }

}


