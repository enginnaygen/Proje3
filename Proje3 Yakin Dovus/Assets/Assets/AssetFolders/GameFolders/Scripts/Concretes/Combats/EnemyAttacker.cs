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
             yield return new WaitForSeconds(delay); // yani bý animasyon girdiðinde her türlü playerin damage'i azalýyor, görüntü olarak vurmasa da player'a olayerýn caný her türlü bu animasyon girdiðinde azalacak
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

        
        Debug.Log("düþman vurdu");
      
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
