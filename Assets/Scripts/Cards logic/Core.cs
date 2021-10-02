using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Core
{
    public static int score;
    public static int lives;


    public delegate void ScoreAction();
    public static event ScoreAction addScoreEvent;

    public delegate void LifeAction();
    public static event LifeAction removeLiveEvent;

    public static void AddScore()
    {
        score++;
    }

    public static void RemoveLive()
    {
        lives--;
        if (lives.Equals(0))
        {
            EndGame();
        }
    }

    private static void EndGame()
    {

    }
}
