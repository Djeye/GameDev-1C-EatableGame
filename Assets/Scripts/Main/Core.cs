using UnityEngine;
using System.IO;

public static class Core
{
    private const string FILE_PATH = "Assets/config.txt";
    public static int score;

    public static int livesCount;
    public static int timeOut;
    public static int maxCombo;

    public delegate void ScoreAction();
    public static event ScoreAction AddScoreEvent;

    public delegate void LifeAction();
    public static event LifeAction RemoveLiveEvent;

    public delegate void EndGameAction();
    public static event EndGameAction EndGameEvent;

    public static bool isGameEnded = false;

    public static void AddScore()
    {
        score++;
        AddScoreEvent();
    }

    public static void RemoveLive()
    {
        RemoveLiveEvent();

        livesCount--;
        if (livesCount.Equals(0))
        {
            EndGame();
        }
    }

    private static void EndGame()
    {
        EndGameEvent();
        isGameEnded = true;
    }

    public static void LoadConfigData()
    {
        var data = JsonUtility.FromJson<Config>(new StreamReader(FILE_PATH).ReadToEnd());

        livesCount = data._maxLives;
        maxCombo = data._maxComboScore;
        timeOut = data._timeOutTime;
    }
}

