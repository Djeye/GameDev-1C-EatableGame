using UnityEngine;

public class Config
{
    public int _maxLives;
    public int _timeOutTime;
    public int _maxComboScore;

    public Config(int maxLives, int timeOutTime, int maxComboScore)
    {
        _maxLives = maxLives;
        _timeOutTime = timeOutTime;
        _maxComboScore = maxComboScore;
    }

    public string ToJson()
    {
        return JsonUtility.ToJson(this);
    }
}
