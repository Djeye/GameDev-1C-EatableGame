using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpritesManager : MonoBehaviour
{
    [SerializeField] private List<AssetReferenceSprite> eatableObjects;
    [SerializeField] private List<AssetReferenceSprite> uneatableObjects;

    private SpriteRenderer _cardFaceRenderer;

    private AssetReferenceSprite currentCardSprite;
    public void LoadCard(CardImage cardImage, bool isEatable)
    {
        _cardFaceRenderer = cardImage.GetComponent<SpriteRenderer>();

        if (isEatable)
            currentCardSprite = eatableObjects[Random.Range(0, eatableObjects.Count - 1)];
        else
            currentCardSprite = uneatableObjects[Random.Range(0, uneatableObjects.Count - 1)];

        currentCardSprite.LoadAssetAsync().Completed += SpawnCardSpriteFace;
    }

    private void SpawnCardSpriteFace(AsyncOperationHandle<Sprite> obj)
    {
        if (obj.Status.Equals(AsyncOperationStatus.Succeeded))
        {
            _cardFaceRenderer.sprite = obj.Result;
        }
    }

    public void UnloadSprites()
    {
        currentCardSprite.ReleaseAsset();
    }
}
