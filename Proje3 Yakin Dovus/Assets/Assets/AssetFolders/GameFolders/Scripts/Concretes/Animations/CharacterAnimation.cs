using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Animations;
using UnityEngine;


namespace UdemyProject3.Animations
{
    public class CharacterAnimation : IMyAnimation
    {
        Animator _animator;

        public CharacterAnimation(Animator animator)
        {
               _animator = animator;
        }

        public void AttackAnimation()
        {
            _animator.SetTrigger("attack");

        }

        public void DeadAnimation()
        {
            _animator.SetTrigger("dead");
        }

        public void JumpAnimation(bool isJump)
        {
            _animator.SetBool("isJump", isJump);
        }

        public void MoveAnimation(float moveSpeed)
        {
            _animator.SetFloat("moveSpeed", Mathf.Abs(moveSpeed));
        }

        public void TakeHitAnimation()
        {
            _animator.SetTrigger("takeHit");
        }
    }
}
