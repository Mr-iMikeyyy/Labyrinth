using System;

[Serializable]
public class HighScore
{
    public string name;
    public float totalTime;

    public HighScore(string name, float totalTime)
    {
        this.name = name;
        this.totalTime = totalTime;
    }
}
