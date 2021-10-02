using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private const int yAnchor = -15;
    private SpritesManager spritesManager;
    private bool _isEatable;
    private Animator animator;
    private bool isAnimated;

    private void Awake()
    {
        spritesManager = GetComponentInParent<SpritesManager>();
        animator = GetComponent<Animator>();
    }

    public void MoveByMouse(float pointerXPos)
    {
        transform.position = new Vector2(pointerXPos, transform.right.y * pointerXPos);
        transform.up = (Vector2)transform.position - new Vector2(0, yAnchor);
    }

    public void ReturnCardPosition(Vector3 pos)
    {
        transform.position = pos;
        transform.up = Vector2.up;
    }

    public void Destroy()
    {
        transform.SetParent(transform.parent.parent);
        spritesManager.UnloadSprites();
        Destroy(this.gameObject);
    }

    public void SetEatable(bool isEatable)
    {
        _isEatable = isEatable;
    }

    public bool GetEatable()
    {
        return _isEatable;
    }

    public CardImage ChildSprite()
    {
        return GetComponentInChildren<CardImage>();
    }

    public void AppearAnimationEnds()
    {
        isAnimated = false;
    }

    public bool IsAnimated()
    {
        return isAnimated;
    }

    public void ChangeAnimatorState(bool state)
    {
        animator.enabled = state;
    }
}
