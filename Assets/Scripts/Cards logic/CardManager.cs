using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private const string DISAPPEAR_TRIGGER = "Disappear";
    [SerializeField] Card card;
    [SerializeField] MagicCircle magicCircle;
    private Animator animator;
    private SpritesManager spritesManager;

    private void Awake()
    {
        spritesManager = GetComponent<SpritesManager>();
    }


    private void Start()
    {
        SpawnNewCard();
    }

    public void SpawnNewCard()
    {
        magicCircle.CreateAnimation();
        var newCard = Instantiate(card, transform.position, Quaternion.identity, transform);
        newCard.name = card.name;
        bool isEatable = IsCardEatable;
        newCard.SetEatable(isEatable);
        spritesManager.LoadCard(newCard.ChildSprite(), isEatable);
    }

    private bool IsCardEatable { get { return Random.Range(0, 2).Equals(0); } }
}
