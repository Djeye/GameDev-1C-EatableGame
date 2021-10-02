using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Arrow : Effect
{
    private Animator animator;
    private Image image;
    private TextMeshProUGUI text;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        image = GetComponent<Image>();
        text = GetComponentInChildren<TextMeshProUGUI>();
        EndAnimation();
    }

    override public void EndAnimation()
    {
        image.enabled = false;
        text.enabled = false;
    }

    override public void StartAnimation()
    {
        animator.SetTrigger("Animate");
        image.enabled = true;
        text.enabled = true;
    }
}
