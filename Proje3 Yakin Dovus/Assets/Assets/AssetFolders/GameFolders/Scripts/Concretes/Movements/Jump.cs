using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Movements;
using UnityEngine;


namespace UdemyProject3.Movements
{
    public class Jump :IJump
    {
        Rigidbody2D _rigidbody2D;

        public Jump(Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
        }

        public void JumpAction(float jumpSpeed)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeed);
        }
    }


}
