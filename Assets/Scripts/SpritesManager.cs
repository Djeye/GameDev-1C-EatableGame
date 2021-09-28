using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class SpritesManager : MonoBehaviour
{
    [SerializeField] private AssetReferenceSprite cardFrame;
    [SerializeField] private List<AssetReferenceSprite> eatableObjects;
    [SerializeField] private List<AssetReferenceSprite> uneatableObjects;

    private SpriteRenderer _cardFrameRenderer, _cardFaceRenderer;
    // Start is called before the first frame update
    void Start()
    {
        GetRendererComponentsInChildrens();

        LoadSprites();
    }

    private void LoadSprites()
    {
        cardFrame.LoadAssetAsync().Completed += SpawnCardSpriteFrame;

        bool isChooseEatable = Random.Range(0, 2).Equals(0);
        if (isChooseEatable)
            eatableObjects[Random.Range(0, eatableObjects.Count-1)].LoadAssetAsync().Completed += SpawnCardSpriteFace;
        else
            uneatableObjects[Random.Range(0, uneatableObjects.Count - 1)].LoadAssetAsync().Completed += SpawnCardSpriteFace;
    }

    private void GetRendererComponentsInChildrens()
    {
        _cardFrameRenderer = GetComponentsInChildren<SpriteRenderer>()[0];
        _cardFaceRenderer = GetComponentsInChildren<SpriteRenderer>()[1];
    }

    private void SpawnCardSpriteFrame(AsyncOperationHandle<Sprite> obj)
    {   
        if (obj.Status.Equals(AsyncOperationStatus.Succeeded))
        {
            _cardFrameRenderer.sprite = obj.Result;
        }
    }

    private void SpawnCardSpriteFace(AsyncOperationHandle<Sprite> obj)
    {   
        if (obj.Status.Equals(AsyncOperationStatus.Succeeded))
        {
            _cardFaceRenderer.sprite = obj.Result;
        }
    }
}
