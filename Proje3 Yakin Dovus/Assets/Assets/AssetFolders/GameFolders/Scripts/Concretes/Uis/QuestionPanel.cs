using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Combats;
using UdemyProject3.Controllers;
using UnityEngine;
using UnityEngine.UI;

public class QuestionPanel : MonoBehaviour
{
    [SerializeField] PlayerController playerController;
    Health _playerHealth;
    [SerializeField] GameObject resultPanel;
    int _life;

    [SerializeField]Text questiontText,resultText;
  

    public void SetLifeCount(int life)
    {
        _life = life;
        questiontText.text = "Pay " + _life + " diamonds";
       
    }

    public void YesClick()
    {
        if (playerController.Score >= _life)
        {
            if(playerController.GetComponent<Health>().currentHealt+_life>100)
            {
                resultText.text = "you cannot get over max health";
                resultPanel.SetActive(true);
                this.gameObject.SetActive(false);



            }
            else
            {
                resultText.text = "you purchase " + _life + " life";
                resultPanel.SetActive(true);
                _playerHealth = playerController.GetComponent<Health>();
                _playerHealth.currentHealt += _life;
                playerController.Score -= _life;
                this.gameObject.SetActive(false);
            }
            


        }
        else
        {
            resultText.text = "not enough diamonds";
            resultPanel.SetActive(true);
            this.gameObject.SetActive(false);



        }
    }
}
