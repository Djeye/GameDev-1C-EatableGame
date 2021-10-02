﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public static class Core
{
    private const string FILE_PATH = "config.txt";
    public static int score;

    public static int livesCount;
    public static int timeOut;
    public static int maxCombo;

    public delegate void ScoreAction();
    public static event ScoreAction addScoreEvent;

    public delegate void LifeAction();
    public static event LifeAction removeLiveEvent;

    public static void AddScore()
    {
        score++;
        addScoreEvent();
    }

    public static void RemoveLive()
    {
        removeLiveEvent();
        livesCount--;
        if (livesCount.Equals(0))
        {
            EndGame();
        }
    }

    private static void EndGame()
    {
        Debug.Log("endgame");
    }

    public static void InitializeConfig()
    {
        var data = JsonUtility.FromJson<Config>(new StreamReader(FILE_PATH).ReadToEnd());

        livesCount = data._maxLives;
        maxCombo = data._maxComboScore;
        timeOut = data._timeOutTime;
    }
}

