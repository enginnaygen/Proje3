using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Combats;
using UdemyProject3.Combats;
using UdemyProject3.Controllers;
using UnityEngine;



namespace UdemyProject3.Uis
{
    public class ShopGameObject : MonoBehaviour
    {

        [SerializeField] QuestionPanel questionPanel;
        public void BuyLife(int life)
        {
            questionPanel.gameObject.SetActive(true);
            questionPanel.SetLifeCount(life);
           
        }
    }

}
