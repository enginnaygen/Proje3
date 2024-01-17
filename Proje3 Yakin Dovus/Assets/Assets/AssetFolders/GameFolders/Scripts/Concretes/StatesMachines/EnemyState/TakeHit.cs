using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Animations;
using UdemyProject3.Abstracts.Combats;
using UnityEngine;


namespace UdemyProject3.StatesMachines.EnemyStates
{
    public class TakeHit : IState
    {
        IMyAnimation _animation;

        float _currentDelayTime=0;
        float _maxDelayTime=0.1f;
        public bool IsTakeHit { get; private set; }
        public TakeHit(IHealth health, IMyAnimation animation)
        {
            _animation = animation;
            health.OnHealthChanged += (currentHealth,maxHealth)=> OnEnter(); //anonim metodu evente atýyorum ve onun içinde OnEnter çalýþtýrýyoruz
        }
        /*public TakeHit(IMyAnimation animation)
        {
            _animation = animation;
            OnEnter(); //anonim metodu evente atýyorum ve onun içinde OnEnter çalýþtýrýyoruz
        }*/
        public void OnEnter()
        {
            IsTakeHit = true;
        }

        public void OnExit()
        {
            _currentDelayTime = 0;
            _animation.MoveAnimation(0);
        }

        public void Tick()
        {
            _currentDelayTime += Time.deltaTime;
            if(_currentDelayTime > _maxDelayTime && IsTakeHit) 
            {
                _animation.TakeHitAnimation();
                IsTakeHit=false;
            }
            Debug.Log("TakeHit On Tick");
        }
    }

}
