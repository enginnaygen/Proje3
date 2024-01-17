using System.Collections;
using System.Collections.Generic;
using UdemyProject3.Abstracts.Movements;
using UdemyProject3.Controllers;
using UnityEngine;


namespace UdemyProject3.Movements
{
    public class StopAtEdge : MonoBehaviour , IStopAtEdge
    {
        [SerializeField] float distance = 0.3f;
        [SerializeField] LayerMask layerMask;
        [SerializeField] Transform enemyFoot;




        public bool ReachEdge()
        {
            RaycastHit2D hit = Physics2D.Raycast(enemyFoot.position, Vector2.down, distance, layerMask);
            Debug.DrawRay(enemyFoot.position, Vector2.down * distance, Color.red);

            bool result = hit.collider != null;
      

            if (result) //boþ deðilse uç noktaya ulaþýlmamýþtýr
            {                
                //_direction *= -transform.localScale.x;
                return false;
            }
            else    //boþ ise uç noktaya gelinmiþtir
            { 
                return true; 
            }
        }
    }

           /*{
                float x = GetXPosition();
                float y = _collider.bounds.min.y;

                 Vector2 origin = new Vector2(x, y);

                 RaycastHit2D raycastHit2D = Physics2D.Raycast(origin,Vector2.down,distance, layerMask);
                 Debug.DrawRay(origin, Vector2.down * distance, Color.red);

                bool result = raycastHit2D != null;
                Debug.Log(result);
                if (result)
               {
             //_direction *= -transform.localScale.x;
                    return false;
                    }
                 else
                  return true;
                        

               private float GetXPosition()
                {
                 return _direction == 1f ? _collider.bounds.max.x : _collider.bounds.min.x;
}                   */


    }


