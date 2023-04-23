using System;

[Serializable]
public class HighScore
{
    public string name;
    public int level;
    public float time;

    public HighScore(string name, int level, float time)
    {
        this.name = name;
        this.level = level;
        this.time = time;
    }
}
