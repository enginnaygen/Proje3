using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Controllers;
using UdemyProject3.Movements;
using UnityEngine;


namespace UdemyProject3.Abstracts.Movements
{
    public interface IMover
    {
        public void PlayerMove(float horizontal);
        public void EnemyMove(float horizontal);

    }
}

