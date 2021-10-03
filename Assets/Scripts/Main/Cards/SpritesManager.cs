using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpritesManager : MonoBehaviour
{
    [SerializeField] private List<AssetReferenceSprite> eatableObjects;
    [SerializeField] private List<AssetReferenceSprite> uneatableObjects;

    private SpriteRenderer _cardFaceRenderer;
    private AssetReferenceSprite _currentCardSprite;

    public void LoadCardSprite(CardImage cardImage, bool isEatable, int number)
    {
        _cardFaceRenderer = cardImage.GetComponent<SpriteRenderer>();

        if (isEatable)
            _currentCardSprite = eatableObjects[number];
        else
            _currentCardSprite = uneatableObjects[number];

        _currentCardSprite.LoadAssetAsync().Completed += ApplyCardFaceSprite;
    }

    private void ApplyCardFaceSprite(AsyncOperationHandle<Sprite> obj)
    {
        if (obj.Status.Equals(AsyncOperationStatus.Succeeded))
        {
            _cardFaceRenderer.sprite = obj.Result;
        }
    }

    public void UnloadCardSprites()
    {
        _currentCardSprite.ReleaseAsset();
    }
}
