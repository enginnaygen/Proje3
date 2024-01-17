using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Movements;
using UdemyProject3.Controllers;
using UnityEngine;


namespace UdemyProject3.Movements
{
    public class MoverWithTranslate : IMover
    {
        float _moveSpeed = 1f;
        PlayerController _playerController;
        EnemyController _enemyController;
        public MoverWithTranslate(PlayerController playerController,float moveSpeed) //construction metod
        {
            _playerController = playerController;
            _moveSpeed = moveSpeed;
            //moveSpeed = _moveSpeed;

        }
        public MoverWithTranslate(EnemyController enemyController, float moveSpeed) //construction metod
        {
            _enemyController = enemyController;
            _moveSpeed = moveSpeed;
            //moveSpeed = _moveSpeed;

        }

        public void PlayerMove(float horizontal)
        {
            if (horizontal == 0) return;
                _playerController.GetComponent<Rigidbody2D>().velocity = new Vector2(0,_playerController.GetComponent<Rigidbody2D>().velocity.y);
                _playerController.transform.Translate(Vector2.right * horizontal * Time.deltaTime * _moveSpeed);
                //_playerController.transform.Translate(Vector2.zero);
        }
        public void EnemyMove(float horizontal)
        {
            if (horizontal == 0) return;
            _enemyController.transform.Translate(Vector2.right * horizontal * Time.deltaTime * _moveSpeed);
            //_playerController.transform.Translate(Vector2.zero);
        }


    }

}
