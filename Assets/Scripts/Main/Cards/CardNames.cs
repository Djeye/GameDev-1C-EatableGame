using System.Collections.Generic;
using UnityEngine;

public class CardNames : MonoBehaviour
{
    [SerializeField] public List<string> eatableObjects;
    [SerializeField] public List<string> uneatableObjects;

    public string GetCardName(bool isEatable, int i)
    {
        if (isEatable)
            return eatableObjects[i];
        else
            return uneatableObjects[i];
    }

    public int GetCardsCount(bool isEatable)
    {
        if (isEatable)
            return eatableObjects.Count;
        else
            return uneatableObjects.Count;
    }
}
