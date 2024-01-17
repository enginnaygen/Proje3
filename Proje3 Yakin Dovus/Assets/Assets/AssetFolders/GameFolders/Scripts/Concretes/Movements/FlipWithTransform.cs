using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Movements;
using UnityEngine;


namespace UdemyProject3.Movements
{
    public class FlipWithTransform : IFlip
    {
        Transform _playerTransform;
        public FlipWithTransform(Transform playerTransform)
        {
            _playerTransform = playerTransform;
        }

        public void Turn(float speed)
        {
            if (speed < 0)
            {
                _playerTransform.localScale = new Vector2(-1, 1);

            }
            else if(speed > 0)
            {
                _playerTransform.localScale = new Vector2(1, 1);

            }

        }
    }

    

}
