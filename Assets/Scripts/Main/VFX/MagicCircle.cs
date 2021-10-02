using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : Effect
{
    private Animator animator;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        EndAnimation();
    }

    override public void StartAnimation()
    {
        sr.enabled = true;
        animator.SetTrigger("Animate");
    }

    override public void EndAnimation()
    {
        sr.enabled = false;
    }
}
