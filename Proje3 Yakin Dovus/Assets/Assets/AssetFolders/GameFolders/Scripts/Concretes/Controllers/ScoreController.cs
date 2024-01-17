using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Controllers;
using UnityEngine;
using UnityEngine.UI;


// bu clas kullanýlmýyors
public class ScoreController : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    [SerializeField] Text scoreText;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerController.Score+=10;
            scoreText.text = "" + playerController.Score;
            Destroy(this.gameObject);
        }
    }
}
