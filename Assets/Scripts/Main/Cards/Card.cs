using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Card : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI cardName;
    
    private const int Y_ANCHOR = -15;
    private SpritesManager spritesManager;
    private bool _isEatable;
    private Animator animator;


    private void Awake()
    {
        spritesManager = GetComponentInParent<SpritesManager>();
        animator = GetComponent<Animator>();
    }

    public void MoveByMouse(float pointerXPos)
    {
        transform.position = new Vector2(pointerXPos, transform.right.y * pointerXPos);
        transform.up = (Vector2)transform.position - new Vector2(0, Y_ANCHOR);
    }

    public void ReturnCardPosition(Vector3 pos)
    {
        transform.position = pos;
        transform.up = Vector2.up;
    }

    public void DestroyCard()
    {
        transform.SetParent(transform.parent.parent);
        spritesManager.UnloadSprites();
        animator.SetTrigger("Destroy");
    }

    public void DestroyAfterEndOfAnimation()
    {
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

    public void SetCardName(string name) => cardName.text = name;
}
