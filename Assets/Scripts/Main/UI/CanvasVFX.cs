using UnityEngine;
using UnityEngine.UI;

public class CanvasVFX : MonoBehaviour
{
    [SerializeField] Image star;
    [SerializeField] Image heart;

    private void Start()
    {
        Core.AddScoreEvent += SpawnStar;
        Core.RemoveLiveEvent += SpawnHeart;
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
        Core.AddScoreEvent -= SpawnStar;
        Core.RemoveLiveEvent -= SpawnHeart;
    }
}
