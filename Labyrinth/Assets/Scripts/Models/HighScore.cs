public class HighScore{
    public string name { get; set; }
    public int level { get; set; }
    public float time { get; set; }

    public HighScore(string name, int level, float time) {
        this.name = name;
        this.level = level;
        this.time = time;
    }
}