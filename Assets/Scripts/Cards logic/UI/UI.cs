using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject heart;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] int gameHearts;

    void Start()
    {
        for (int i = 0; i < gameHearts - 1 ; i++)
        {
            Instantiate(heart, heart.transform.parent);
        }
        Core.addScoreEvent +=
    }

    private void Update()
    {
        
    }

}
