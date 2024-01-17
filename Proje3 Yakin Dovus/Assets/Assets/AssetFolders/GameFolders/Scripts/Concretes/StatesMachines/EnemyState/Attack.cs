using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Animations;
using UdemyProject3.Abstracts.Combats;
using UdemyProject3.Controllers;
using UnityEngine;

namespace UdemyProject3.StatesMachines.EnemyStates
{
    public class Attack : IState
    {
        IMyAnimation _animation;
        IAttacker _attacker;
        IHealth _playerHealth;
        EnemyController _enemyController;
        PlayerController _playerController;

        float _currentAttackTime;
        float _maxAttackTime;

        public Attack(EnemyController enemyController, PlayerController playerController,IMyAnimation animation, IAttacker attacker, float maxAttackTime)
        {
            _animation = animation;
            _attacker = attacker;
            _playerHealth = playerController.GetComponent<IHealth>();
            _maxAttackTime = maxAttackTime;
            _enemyController = enemyController;
            _playerController = playerController;

            
        }
        public void OnEnter()
        {
            _currentAttackTime = 0f;
        }

        public void OnExit()
        {

        }

        public void Tick()
        {
            _currentAttackTime += Time.deltaTime;
            if(_currentAttackTime > _maxAttackTime)
            {
                _animation.AttackAnimation();
              
                //_attacker.Attack(_playerHealth); //bu olduðunda animasyona girince otomatik damage veriyordu bunu engelledik
                _currentAttackTime = 0f;
            }


            Debug.Log("Attack On Tick");
        }
    }

}

