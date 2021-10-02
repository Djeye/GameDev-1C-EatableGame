using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicCircle : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        sr.enabled = false;
    }

    public void CreateAnimation()
    {
        sr.enabled = true;
        animator.SetTrigger("Animate");
    }

    public void EndAnimation()
    {
        sr.enabled = false;
    }
}
