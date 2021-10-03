using UnityEngine;
using UnityEngine.EventSystems;

public class SwipeCard : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    private Camera _mainCamera;
    private CardManager _cardManager;
    private Card _card;
    
    private float _swipeAreaSize, _cameraViewWidth;

    private void Start()
    {
        _mainCamera = Camera.main;
        _cameraViewWidth = _mainCamera.orthographicSize * _mainCamera.aspect;
        _swipeAreaSize = _cameraViewWidth / 3;

        _cardManager = GetComponent<CardManager>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _card = GetComponentInChildren<Card>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        var pointerWorldXPos = _mainCamera.ScreenToWorldPoint(eventData.position).x;
        _card.MoveByMouse(pointerWorldXPos);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        var pointerWorldXPos = _mainCamera.ScreenToWorldPoint(eventData.position).x;

        bool EatArea = pointerWorldXPos > _swipeAreaSize;
        bool BurnArea = pointerWorldXPos < -_swipeAreaSize;

        ApplyCardAction(EatArea, BurnArea);
    }

    private void ApplyCardAction(bool EatArea, bool BurnArea)
    {
        if (!EatArea && !BurnArea)
        {
            _card.ReturnCardPosition(transform.position);
            return;
        }

        if (BurnArea && _card.GetEatable() || EatArea && !_card.GetEatable())
        {
            Core.RemoveLive();
        }
        else if (EatArea && _card.GetEatable() || BurnArea && !_card.GetEatable())
        {
            Core.AddScore();
        }

        _card.DestroyCard();
        _cardManager.AppearNewCard();
    }
}
