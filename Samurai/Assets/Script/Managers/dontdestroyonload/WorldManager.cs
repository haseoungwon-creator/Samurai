using UnityEngine;

public class WorldManager : Singleton<WorldManager>
{
    public int CurrentChapter { get; private set; } = 0;
    public int CurrentStage { get; private set; } = 1;

    public string CurrentScene { get; private set; }

    public void SetStage(int chapter, int stage)
    {
        CurrentChapter = chapter;
        CurrentStage = stage;
    }

    public void NextStage()
    {
        CurrentStage++;
        NPCManager.Instance.ResetAllTalk();
    }
    public void NextChapter()
    {
        CurrentChapter++;
        CurrentStage = 1;
        NPCManager.Instance.ResetAllTalk();
    }

    public void ResetWorld()
    {
        CurrentChapter = 0;
        CurrentStage = 1;
    }
}
