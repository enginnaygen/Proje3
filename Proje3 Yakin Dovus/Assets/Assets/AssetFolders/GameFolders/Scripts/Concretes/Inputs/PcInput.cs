using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Inputs;
using UnityEngine;


namespace UdemyProject3.Inputs
{
    public class PcInput : IplayerInputs
    {
        public float Horizontal => Input.GetAxis("Horizontal");

        public float Vertical => Input.GetAxis("Vertical");

        public bool IsJump => Input.GetButtonDown("Jump");

        public bool AttackButton => Input.GetButtonDown("Fire1");
    }

}
