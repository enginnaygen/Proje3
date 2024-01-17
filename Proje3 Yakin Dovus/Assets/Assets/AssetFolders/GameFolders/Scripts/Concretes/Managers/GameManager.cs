using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using UdemyProject3.Enums;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UdemyProject3.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] int score;
        
        public static GameManager Instance { get; private set; }

        public event System.Action<SceneTypeEnum> OnSceneChanged;

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
                Instance = this;
                DontDestroyOnLoad(this.gameObject);
            }

        }

        public void SplashScreen(string sceneName)
        {
            SceneTypeEnum sceneType;
            switch (sceneName)
            {
                case "Game":
                    sceneType = SceneTypeEnum.Game;
                    break;
                case "SplashScene":
                    sceneType = SceneTypeEnum.Splash;
                    break;
                default: sceneType = SceneTypeEnum.Menu;
                    break;
            }
            StartCoroutine(SplashScreenAsycn(sceneName, sceneType));
        }

        private IEnumerator SplashScreenAsycn(string sceneName, SceneTypeEnum sceneType)
        {
            yield return SceneManager.LoadSceneAsync("SplashScene", LoadSceneMode.Additive); //LoadSceneMode.Additive olan Scene'in üstüne ekliyor Scene'i
            OnSceneChanged?.Invoke(SceneTypeEnum.Splash);

            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());           
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("SplashScene"));

         //yield return new WaitForSeconds(1f);

            yield return SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
            yield return SceneManager.LoadSceneAsync(sceneName,LoadSceneMode.Additive);

            OnSceneChanged.Invoke(sceneType);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
            //StartGame();
        }
        //burdan sonrasý eski yapý, eski yapýyý kullanmak için yukarýyý pasife al yoksa "Failed to call function SplashScreenAsycn of class GameManager, Calling function SplashScreenAsycn with no parameters but the function requires 2. UnityEngine.MonoBehaviour:StartCoroutine(string)" þeklinde 3 satýrlýk hata veriyor


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

        }
        
        public void SplashScrenn() // 1. iþlem bu start butonuna verilen metod da bu
        {
          StartCoroutine("SplashScreenAsycn");
        }

        private IEnumerator SplashScreenAsycn()
        {
            yield return SceneManager.LoadSceneAsync("SplashScene");
            //yield return new WaitForSeconds(1);

            StartGame();
        }*/

         

        public void QuitGame()
        {
            Debug.Log("Quit");
            Application.Quit();
            
        }


    }

}
