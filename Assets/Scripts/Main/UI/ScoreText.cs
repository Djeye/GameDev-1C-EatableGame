using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    private TextMeshProUGUI _scoreText;

    void Start()
    {
        _scoreText = GetComponent<TextMeshProUGUI>();
        Core.AddScoreEvent += UpdateScoreText;
    }

    private void UpdateScoreText()
    {
        _scoreText.text = Core.score.ToString();
    }

    private void OnDisable()
    {
        Core.AddScoreEvent -= UpdateScoreText;
    }
}
