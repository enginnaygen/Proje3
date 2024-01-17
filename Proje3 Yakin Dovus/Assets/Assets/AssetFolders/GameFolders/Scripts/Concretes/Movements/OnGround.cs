using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class OnGround : MonoBehaviour
{
    [SerializeField]Transform[] transforms;
    [SerializeField]float distance;
    [SerializeField]LayerMask layer;
    public bool onGround { get; set; }
    /*[SerializeField]bool _onGround;
    public bool onGround => _onGround;*/

    void FixedUpdate()
    {
        foreach (Transform footTransforms in transforms)
        {
            OnGroundCheck(footTransforms);
            if (onGround) break;  // sadece 1 tane footun ray atmasý için
        }
    }

    private void OnGroundCheck(Transform footTransform)
    {
        RaycastHit2D hit = Physics2D.Raycast(footTransform.position, Vector2.down,distance,layer);
        Debug.DrawRay(footTransform.position, Vector2.down * distance, Color.red);

        if(hit.collider != null)
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }

}
