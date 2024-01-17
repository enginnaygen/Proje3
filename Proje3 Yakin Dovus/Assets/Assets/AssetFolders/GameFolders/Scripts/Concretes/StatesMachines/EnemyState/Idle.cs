using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Animations;
using UdemyProject3.Abstracts.Movements;
using UdemyProject3.Controllers;
using UnityEngine;

namespace UdemyProject3.StatesMachines.EnemyStates
{
    public class Idle : IState
    {
        IMover _mover;
        IMyAnimation _animation;
        //IFlip _flip;
        //EnemyController _enemyController;

        float _maxStandTime;
        float _currentStandTime;

        public bool IsIdle { get; private set; }


        public Idle(IMover mover, IMyAnimation animation)
        {
            _mover = mover;
            _animation = animation;
            //_flip = flip;
            //_enemyController = enemyController;
        }

        public void OnEnter()
        {
            IsIdle = true;
            _animation.MoveAnimation(0f);
            _maxStandTime = Random.Range(3f, 5f);
        }

        public void OnExit()
        {
            _currentStandTime = 0f;
            //_flip.Turn(_enemyController.transform.localScale.x * -1);
        }

        public void Tick()
        {
            _mover.PlayerMove(0f);
            _currentStandTime += Time.deltaTime;

        
            if(_maxStandTime<_currentStandTime)
            {
                IsIdle = false;
            }

        }
    }

}
