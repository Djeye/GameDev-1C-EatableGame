using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleUsable : Effect
{
    public override void EndAnimation()
    {
        Destroy(this.gameObject);
    }
}
