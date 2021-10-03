using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartLives : MonoBehaviour
{
    [SerializeField] GameObject heart;

    private List<GameObject> _heartList = new List<GameObject>();

    void Start()
    {
        _heartList.Add(heart);
        for (int i = 0; i < Core.livesCount - 1; i++)
        {
            var curHeart = Instantiate(heart, transform);
            _heartList.Add(curHeart);
        }

        Core.RemoveLiveEvent += RemoveHeart;
    }

    private void RemoveHeart()
    {
        if (!_heartList.Count.Equals(0))
        {
            _heartList[_heartList.Count - 1].GetComponentInChildren<HeartUpperImage>().GetComponent<Image>().enabled = false;
            _heartList.RemoveAt(_heartList.Count - 1);
        }
    }

    private void OnDisable()
    {
        Core.RemoveLiveEvent -= RemoveHeart;
    }
}
