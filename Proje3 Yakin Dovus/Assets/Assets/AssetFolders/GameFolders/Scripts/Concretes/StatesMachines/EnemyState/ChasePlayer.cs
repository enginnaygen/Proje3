using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Animations;
using UdemyProject3.Abstracts.Movements;
using UdemyProject3.Controllers;
using UdemyProject3.Movements;
using UnityEngine;

namespace UdemyProject3.StatesMachines.EnemyStates
{
    public class ChasePlayer : IState
    {

        //PlayerController _player;
        //EnemyController _enemy;
        IMover _mover;
        IFlip _flip;
        IMyAnimation _animation;
        IStopAtEdge _stopAtEdge;
        System.Func<bool> _isPlayerRightSide;


        /*public ChasePlayer(EnemyController enemy, PlayerController player,IMover mover,IFlip flip,IMyAnimation animation)
        {
            _player = player;
            _enemy = enemy;
            _mover = mover;
            _flip = flip;
            _animation = animation;
            
        }*/
        public ChasePlayer(System.Func<bool> isPlayerRightSide, IStopAtEdge stopAtEdge, IMover mover, IFlip flip, IMyAnimation animation)
        {

            _mover = mover;
            _flip = flip;
            _animation = animation;
            _isPlayerRightSide = isPlayerRightSide;
            _stopAtEdge = stopAtEdge;

        }
        public void OnEnter()
        {
            _animation.MoveAnimation(1f);
        }

        public void OnExit()
        {
            _animation.MoveAnimation(0);

        }

        public void Tick()
        {
            if (_stopAtEdge.ReachEdge())
            {
               
                _animation.MoveAnimation(0f);
                return;
            }

            /*Vector2 LeftOrRight = _player.transform.position-_enemy.transform.position;

            if(LeftOrRight.x>0 ) 
            {
                _mover.EnemyMove(2.5f);
                _flip.Turn(1f);
            }
            else
            {
                _mover.EnemyMove(-2.5f);
                _flip.Turn(-3f);

            }
            _mover.EnemyMove(LeftOrRight.x > 0 ? 2.5f : -2.5f);
            _flip.Turn(LeftOrRight.x> 0 ? 1f : -1f);*/
            if (_isPlayerRightSide.Invoke())
            {
                _mover.EnemyMove(2.5f);
                _flip.Turn(1f);
            }
            else
            {
                _mover.EnemyMove(-2.5f);
                _flip.Turn(-1f);
            }



            Debug.Log("ChasePlayer On Tick");
        }
        private void ChaseAgain(float moveDirection, float flipDirection, float animationSpeed)
        {
            _mover.EnemyMove(moveDirection);
            _flip.Turn(flipDirection);
            _animation.MoveAnimation(animationSpeed);
        }


    }
}

