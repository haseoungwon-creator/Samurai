[System.Serializable]

public class Dialogue
{
    public string speaker;
    public string line;

    public Dialogue(string speaker,string line)
    {
        this.speaker = speaker;
        this.line = line;
    }
}