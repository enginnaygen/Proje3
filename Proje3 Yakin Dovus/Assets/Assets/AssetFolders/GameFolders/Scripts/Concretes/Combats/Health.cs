using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Animations;
using UdemyProject3.Abstracts.Combats;
using UdemyProject3.Animations;
using UnityEngine;

namespace UdemyProject3.Combats
{
    public class Health : MonoBehaviour, IHealth
    {
        public int health = 3;
        public int currentHealt;
        IMyAnimation _animation;

        public bool IsDead => currentHealt < 1;

        public event Action<int,int> OnHealthChanged;
        public event Action OnDead;


        private void Awake()
        {
            currentHealt = health;
            _animation = new CharacterAnimation(GetComponent<Animator>());
        }
        public void TakeHit(IAttacker attacker)
        {
            if (IsDead) return;

            //_animation.TakeHitAnimation();
            currentHealt -= attacker.Damage;
            OnHealthChanged?.Invoke(currentHealt,health); //OnHealthChanged boþ deðilse burasý çalýþsýn

            if(!IsDead)
            {
                _animation.TakeHitAnimation();
                

            }



            if (IsDead)
            {
                OnDead?.Invoke();
            }
        }
    }

}
