using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UdemyProject3.Abstracts.Combats
{
    public interface ITakeHit
    {
        void TakeHit(IAttacker attacker);
    }

}
