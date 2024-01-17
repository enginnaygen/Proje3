using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UdemyProject3.Controllers
{
    public class ShopController : MonoBehaviour
    {

        [SerializeField] GameObject ShopPanel;
        private void OnTriggerEnter2D(Collider2D collision)
        {
           if(collision.tag=="Player")
            {
                ShopPanel.SetActive(true);
                Time.timeScale = 0f;
            }
        }

        public void ShopClose()
        {
            Time.timeScale = 1;
        }
    }

}
