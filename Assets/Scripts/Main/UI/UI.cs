using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject endPanel;
    [SerializeField] TextMeshProUGUI endPanelscoreText;
    [SerializeField] GameObject heart;
    [SerializeField] TextMeshProUGUI scoreText;

    private List<GameObject> _heartList = new List<GameObject>();

    void Start()
    {
        _heartList.Add(heart);
        for (int i = 0; i < Core.livesCount - 1; i++)
        {
            var curHeart = Instantiate(heart, heart.transform.parent);
            _heartList.Add(curHeart);
        }
        Core.addScoreEvent += UpdateScoreText;
        Core.removeLiveEvent += RemoveHeart;
        Core.endGameEvent += EndGameProcess;
    }

    private void RemoveHeart()
    {
        if (!_heartList.Count.Equals(0))
        {
            _heartList[_heartList.Count - 1].GetComponentInChildren<HeartUpperImage>().GetComponent<Image>().enabled = false;
            _heartList.RemoveAt(_heartList.Count - 1);
        }
    }

    private void EndGameProcess()
    {
        endPanel.SetActive(true);
        endPanelscoreText.text = Core.score.ToString();
    }

    private void UpdateScoreText()
    {
        scoreText.text = Core.score.ToString();
    }

    private void OnDisable()
    {
        Core.addScoreEvent -= UpdateScoreText;
        Core.removeLiveEvent -= RemoveHeart;
        Core.endGameEvent -= EndGameProcess;
    }
}
