using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace UdemyProject3.Abstracts.Inputs
{
    public interface IplayerInputs
    {
        float Horizontal { get; }
        float Vertical { get; }
        bool IsJump { get; }
        bool AttackButton { get; }
        

    }
}
