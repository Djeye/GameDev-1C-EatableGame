using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    [SerializeField] private List<Effect> _vfxEffects;

    public void ProcessAnimation()
    {
        foreach(Effect effect in _vfxEffects)
        {
            effect.StartAnimation();
        }
    }
}
