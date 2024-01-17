using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Animations;
using UdemyProject3.Abstracts.Movements;
using UdemyProject3.Controllers;
using UnityEngine;

namespace UdemyProject3.StatesMachines.EnemyStates
{
    public class Walk : IState
    {
        IMover _mover;
        IMyAnimation _animation;
        IFlip _flip;
        int _patrolIndex = 0;
        float _direction;
        Transform[] _patrols;
        Transform _currentPatrolPoint;
        EnemyController _enemyController;
        public bool isWalk { get; private set; }

        public Walk(EnemyController enemyController, IMover mover, IMyAnimation animation,IFlip flip, params Transform[] patrols)
        {
            _mover = mover;
            _animation = animation;
            _flip = flip;
            _patrols = patrols;
            _enemyController = enemyController;
            
        }
        public void OnEnter()
        {
            if (_patrols.Length<1) return;
           
            _currentPatrolPoint = _patrols[_patrolIndex];
            Vector2 leftOrRight = _currentPatrolPoint.position - _enemyController.transform.position;
            /*if(leftOrRight.x>0)
            {
                _flip.Turn(1f);
            }
            else
            {
                _flip.Turn(-1f);
            }*/
            _flip.Turn(leftOrRight.x > 0f ? 1f : -1f);




            _direction = _enemyController.transform.localScale.x;
            isWalk = true;
            _animation.MoveAnimation(1f);
        }

        public void OnExit()
        {

            //_flip.Turn(_direction);
            _animation.MoveAnimation(0f);


            isWalk = false;

            _patrolIndex++;

            if (_patrolIndex >= _patrols.Length)
            { 
                _patrolIndex = 0; 
            }
            //_currentPatrol = _patrols[_patrolIndex];
        }

        public void Tick()
        {
            if(_currentPatrolPoint ==null) return;
            if ((Vector2.Distance(_enemyController.transform.position,_currentPatrolPoint.position)<=0.3f))
            {
                isWalk = false;
                return;
            }
            _mover.EnemyMove(_direction);

            Debug.Log("Walk On Tick");
        }
    }

}
