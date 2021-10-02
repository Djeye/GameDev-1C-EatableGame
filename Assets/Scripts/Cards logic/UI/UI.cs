using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject heart;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int gameHearts;


    private List<GameObject> _heartList = new List<GameObject>();

    void Start()
    {
        _heartList.Add(heart);
        for (int i = 0; i < gameHearts - 1 ; i++)
        {
            var curHeart = Instantiate(heart, heart.transform.parent);
            _heartList.Add(curHeart);
        }
        Core.addScoreEvent += UpdateScoreText;
        Core.removeLiveEvent += RemoveHeart;
    }

    private void RemoveHeart()
    {
        _heartList[_heartList.Count - 1].GetComponentInChildren<HeartUpperImage>().GetComponent<Image>().enabled = false;
        _heartList.RemoveAt(_heartList.Count - 1);
    }

    private void UpdateScoreText() 
    {
        scoreText.text = Core.score.ToString();
    }

    private void OnDisable()
    {
        Core.addScoreEvent -= UpdateScoreText;
        Core.removeLiveEvent -= RemoveHeart;
    }
}
