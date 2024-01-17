using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Combats;
using UdemyProject3.Combats;
using UdemyProject3.Controllers;
using UnityEngine;
using UnityEngine.UI;


namespace UdemyProject3.Uis
{
    public class DisplayHealthGameScene : MonoBehaviour
    {
        Image _healthImage;
        //IHealth _health;
        float _maxHealth, _currentHealth;

        private void Awake()
        {
            _healthImage = GetComponent<Image>();

        }

        private void Update()
        {
            _currentHealth = FindObjectOfType<PlayerController>().GetComponent<Health>().currentHealt;
            _maxHealth = FindObjectOfType<PlayerController>().GetComponent<Health>().health;
            float result = (float)_currentHealth / (float)_maxHealth;
            _healthImage.fillAmount = result;
            //Debug.Log(result);
            //HandleHealthChanged(int currentHealth, int maxHealth);
        }
        /*private void OnEnable()
        {
            _health = FindObjectOfType<PlayerController>().GetComponent<Health>();
            _health.OnHealthChanged += HandleHealthChanged;
        }

        /*private void OnDisable()
        {
            _health.OnHealthChanged -= HandleHealthChanged;

        }*/

        /*private void HandleHealthChanged()
        {
            //float result = (float)currentHealth / (float)maxHealth;
            Debug.Log(result);
        }*/
    }

}
