using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] private List<Effect> vfx;

    public void ProcessAnimation()
    {
        foreach(Effect effect in vfx){
            effect.StartAnimation();
        }
    }
}
