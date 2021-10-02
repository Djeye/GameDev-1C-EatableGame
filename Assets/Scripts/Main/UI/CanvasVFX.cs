using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasVFX : MonoBehaviour
{
    [SerializeField] Image star;
    [SerializeField] Image heart;

    private void Start()
    {
        Core.addScoreEvent += SpawnStar;
        Core.removeLiveEvent += SpawnHeart;
    }

    private void SpawnStar()
    {
        Instantiate(star, transform);
    }

    private void SpawnHeart()
    {
        Instantiate(heart, transform);
    }

    private void OnDisable()
    {
        Core.addScoreEvent -= SpawnStar;
        Core.removeLiveEvent -= SpawnHeart;
    }
}
