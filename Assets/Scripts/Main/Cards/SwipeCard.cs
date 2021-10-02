using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeCard : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Camera mainCamera;
    private float swipeAreaSize, cameraViewWidth;
    private CardManager cardManager;
    private Card card;

    private void Start()
    {
        mainCamera = Camera.main;
        cameraViewWidth = mainCamera.orthographicSize * mainCamera.aspect;
        swipeAreaSize = cameraViewWidth / 3;

        cardManager = GetComponent<CardManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        card = GetComponentInChildren<Card>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        var pointerWorldXPos = mainCamera.ScreenToWorldPoint(eventData.position).x;
        card.MoveByMouse(pointerWorldXPos);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var pointerWorldXPos = mainCamera.ScreenToWorldPoint(eventData.position).x;

        bool EatArea = pointerWorldXPos > swipeAreaSize;
        bool BurnArea = pointerWorldXPos < -swipeAreaSize;

        if (!EatArea && !BurnArea)
        {
            card.ReturnCardPosition(transform.position);
            return;
        }

        if (BurnArea && card.GetEatable() || EatArea && !card.GetEatable())
        {
            Core.RemoveLive();
        }
        else if (EatArea && card.GetEatable() || BurnArea && !card.GetEatable())
        {
            Core.AddScore();
        }

        card.DestroyCard();
        cardManager.SpawnNewCard();
    }
}
