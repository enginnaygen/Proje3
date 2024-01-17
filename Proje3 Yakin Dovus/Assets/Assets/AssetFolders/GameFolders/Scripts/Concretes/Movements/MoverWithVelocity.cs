using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Movements;
using UdemyProject3.Controllers;
using UnityEngine;


namespace UdemyProject3.Movements
{
    public class MoverWithVelocity : IMover
    {
        float speed=2;
        Rigidbody2D _rb2D;
        public MoverWithVelocity(PlayerController playercontroller)
        {
           _rb2D= playercontroller.GetComponent<Rigidbody2D>();     
        }
        public MoverWithVelocity(EnemyController enemyController)
        {
            _rb2D = enemyController.GetComponent<Rigidbody2D>();
        }

        public void EnemyMove(float horizontal)
        {
            throw new System.NotImplementedException();
        }

        public void Move(float horizontal)
        {
            _rb2D.velocity = new Vector2(horizontal * speed, _rb2D.velocity.y);
            //_rb2D.velocity = Vector2.zero;

        }

        public void PlayerMove(float horizontal)
        {
            throw new System.NotImplementedException();
        }
    }

}
