using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationImpactWatcher : MonoBehaviour
{
    public event System.Action OnImpact;

    public void Impact()
    {
        OnImpact?.Invoke(); //beni kim dinliyorsa çalýþsýn, boþ deðilse çalýþsýn
    }
}
