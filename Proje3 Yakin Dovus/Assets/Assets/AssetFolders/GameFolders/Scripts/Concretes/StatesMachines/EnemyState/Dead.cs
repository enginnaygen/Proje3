using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Animations;
using UdemyProject3.Controllers;
using UnityEngine;

namespace UdemyProject3.StatesMachines.EnemyStates
{
    public class Dead : IState
    {

        IMyAnimation _animation;
        EnemyController _controller;
        System.Action _deadCallBack;

        float _currentTime=0f;
        public Dead(IMyAnimation animation, EnemyController controller, System.Action deadCallback)
        {
            _controller = controller;
            _animation = animation;
            _deadCallBack = deadCallback;
        }
        public void OnEnter()
        {
            _animation.DeadAnimation();
            _controller.GetComponent<BoxCollider2D>().enabled = false;
            _deadCallBack?.Invoke();
        }

        public void OnExit()
        {
            _currentTime = 0f;
        }

        public void Tick()
        {
            _currentTime += Time.deltaTime;

            if(_currentTime > 5f) 
            { 
             Object.Destroy(_controller.gameObject);
            }
            Debug.Log("Dead On Tick");
        }
    }

}
