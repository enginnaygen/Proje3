using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Combats;
using UnityEngine;

public class EnemyAttacker : Attacker
{
    [SerializeField] Transform attackDirection;
    [SerializeField] float impactRadius;
    Collider2D[] _collidersInCircle;
    //[SerializeField] float delay;

    private void Awake()
    {
        _collidersInCircle = new Collider2D[10];
        GetComponent<AnimationImpactWatcher>().OnImpact += HandleImpact;
    }
    /* public override void Attack(ITakeHit takeHit)
     {
         StartCoroutine(Attackk());  
         IEnumerator Attackk()
         {
             yield return new WaitForSeconds(delay); // yani b� animasyon girdi�inde her t�rl� playerin damage'i azal�yor, g�r�nt� olarak vurmasa da player'a olayer�n can� her t�rl� bu animasyon girdi�inde azalacak
             takeHit.TakeHit(this);

         }

     }*/

    

    void HandleImpact()
    {
        int hitCount = Physics2D.OverlapCircleNonAlloc(attackDirection.position, impactRadius, _collidersInCircle);

        for (int i = 0; i < hitCount; i++)
        {
            ITakeHit takeHit = _collidersInCircle[i].GetComponent<ITakeHit>();
            if (takeHit != null)
            {
                Attack(takeHit);
                
                //takeHit.TakeHit(this);
            }
        }

        
        Debug.Log("d��man vurdu");
      
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
