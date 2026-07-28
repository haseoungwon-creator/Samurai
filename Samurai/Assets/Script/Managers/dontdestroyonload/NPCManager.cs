using System.Collections.Generic;

public class NPCManager : Singleton<NPCManager>
{
    private readonly List<NPCBase> npcList = new();

    public void Register(NPCBase npc)
    {
        if(!npcList.Contains(npc)) 
            npcList.Add(npc);
    }

    public void Unregister(NPCBase npc)
    {
        npcList.Remove(npc);
    }

    public void ResetAllTalk()
    {
        foreach (NPCBase npc in npcList)
        {
            if(npc != null)
                npc.ResetTalk();
        }
    }
}
