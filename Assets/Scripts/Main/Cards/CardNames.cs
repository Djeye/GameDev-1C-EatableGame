using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardNames : MonoBehaviour
{
    [SerializeField] public List<string> eatableObjects;
    [SerializeField] public List<string> uneatableObjects;

    public string GetCardName(bool isEatable, int i)
    {
        string name;
        if (isEatable)
            name = eatableObjects[i];
        else
            name = uneatableObjects[i];
        return name;
    }

    public int GetCardsCount(bool isEatable) { 
        if (isEatable)
            return eatableObjects.Count;
        else
            return uneatableObjects.Count;
    } 
}
