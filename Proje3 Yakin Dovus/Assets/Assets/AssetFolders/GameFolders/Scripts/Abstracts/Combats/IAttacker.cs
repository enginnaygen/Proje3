using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UdemyProject3.Abstracts.Combats
{
    public interface IAttacker
    {
        int Damage { get;}
        public void Attack(ITakeHit takeHit);

    }

}
