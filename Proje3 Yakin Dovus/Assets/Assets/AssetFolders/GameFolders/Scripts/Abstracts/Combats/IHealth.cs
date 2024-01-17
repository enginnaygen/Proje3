using System;
using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Combats;
using UnityEngine;

namespace UdemyProject3.Abstracts.Combats
{
    public interface IHealth : ITakeHit
    {
        event System.Action<int,int> OnHealthChanged;
        event System.Action OnDead;

        bool IsDead { get; }
    }

}
