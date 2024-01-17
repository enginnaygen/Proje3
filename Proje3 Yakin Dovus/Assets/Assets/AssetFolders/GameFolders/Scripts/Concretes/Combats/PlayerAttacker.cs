using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Combats;
using UnityEngine;


namespace UdemyProject3.Combats
{
    public class PlayerAttacker : Attacker
    {
        [SerializeField] Transform attackDirection;
        [SerializeField] float impactRadius;
        Collider2D[] _collidersInCircle;

        private void Awake()
        {
            _collidersInCircle = new Collider2D[10];
            GetComponent<AnimationImpactWatcher>().OnImpact += HandleImpact;
        }
        /*private void OnEnable()
        {
            
            Debug.Log("Enable Oldu");
            
        }

        private void OnDisable()
        {
            GetComponent<AnimationImpactWatcher>().OnImpact -= HandleImpact;
            Debug.Log("DisableOldu");
        }*/

        void HandleImpact()
        {
            int hitCount=Physics2D.OverlapCircleNonAlloc(attackDirection.position, impactRadius, _collidersInCircle);

            for (int i = 0; i < hitCount; i++)
            {
                ITakeHit takeHit = _collidersInCircle[i].GetComponent<ITakeHit>();
                if (takeHit != null)
                {
                    Attack(takeHit);
                    //takeHit.TakeHit(this);
                }
            }
            Debug.Log("vurdu");
        }

        private void OnDrawGizmos()
        {
            OnDrawGizmosSelected();   
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackDirection.position, impactRadius);
        }

    }

}
