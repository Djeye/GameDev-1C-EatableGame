using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] Card card;
    [SerializeField] VFXManager vfxManager;

    private SpritesManager _spritesManager;
    private CardNames _cardNames;

    private void Awake()
    {
        Core.LoadConfigData();
        _spritesManager = GetComponent<SpritesManager>();
        _cardNames = GetComponent<CardNames>();
    }

    private void Start()
    {
        AppearNewCard();
    }

    public void AppearNewCard()
    {
        if (Core.isGameEnded) return;

        AppearAnimationEffects();

        GenerateNewCard();
    }

    private void AppearAnimationEffects()
    {
        vfxManager.ProcessAnimation();
    }

    private void GenerateNewCard()
    {
        var newCard = Instantiate(card, transform);
        newCard.name = card.name;

        bool isEatable = GetEatableOrUneatable();
        int cardNumber = GetRandomCardNumber(_cardNames.GetCardsCount(isEatable));

        newCard.SetEatable(isEatable);
        newCard.SetCardName(_cardNames.GetCardName(isEatable, cardNumber));

        _spritesManager.LoadCardSprite(newCard.ChildSprite(), isEatable, cardNumber);
    }

    private bool GetEatableOrUneatable()
    {
        return Random.Range(0, 2).Equals(0);
    }

    private int GetRandomCardNumber(int count)
    {
        return Random.Range(0, count);
    }
}
