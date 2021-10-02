using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] Card card;
    [SerializeField] VFXManager vfxManager;
    private SpritesManager spritesManager;
    private CardNames cardNames;


    private void Awake()
    {
        Core.InitializeConfig();
        spritesManager = GetComponent<SpritesManager>();
        cardNames = GetComponent<CardNames>();
    }


    private void Start()
    {
        SpawnNewCard();
    }

    public void SpawnNewCard()
    {
        if (Core.isGameEnded) return;

        vfxManager.ProcessAnimation();
        var newCard = Instantiate(card,  transform);
        newCard.name = card.name;

        bool isEatable = Core.IsCardEatable();
        int number = Random.Range(0, cardNames.GetCardsCount(isEatable));

        newCard.SetEatable(isEatable);
        newCard.SetCardName(cardNames.GetCardName(isEatable, number));
        
        spritesManager.LoadCard(newCard.ChildSprite(), isEatable, number);
    }
}
