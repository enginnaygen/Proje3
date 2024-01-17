using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashController : MonoBehaviour
{
    public void StartGame()
    {
        StartCoroutine(StartGameAsync());
    }

    private IEnumerator StartGameAsync()
    {
        //yield return SceneManager.LoadSceneAsync("Ui");
        yield return SceneManager.LoadSceneAsync("Game");

    }
    void OnEnable()
    {
        StartGame();
    }
}
