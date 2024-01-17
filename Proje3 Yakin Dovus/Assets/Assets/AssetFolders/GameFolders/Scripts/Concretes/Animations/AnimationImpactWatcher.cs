using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationImpactWatcher : MonoBehaviour
{
    public event System.Action OnImpact;

    public void Impact()
    {
        OnImpact?.Invoke(); //beni kim dinliyorsa �al��s�n, bo� de�ilse �al��s�n
    }
}
