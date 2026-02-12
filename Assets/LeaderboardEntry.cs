using System;

[Serializable] // Isso permite que o Unity transforme essa classe em JSON (texto)
public class LeaderboardEntry
{
    public string playerName;
    public int score;
    public long timestamp; // Opcional: para saber quando foi feito o recorde

    public LeaderboardEntry(string name, int score)
    {
        this.playerName = name;
        this.score = score;
        this.timestamp = DateTime.Now.Ticks;
    }
}