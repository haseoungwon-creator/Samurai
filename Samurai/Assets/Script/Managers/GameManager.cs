using UnityEngine;

public class GameManager : Singleton<GameManager>
{

    public GameState Currentstate{  get; private set; }
   


    public void SetState(GameState state)
    {
        Currentstate = state;
    }
}
