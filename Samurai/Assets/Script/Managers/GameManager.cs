using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] GameState gameState;
    public GameState Currentstate{  get; private set; }

    private void Update()
    {
        gameState = Currentstate;
    }



    public void SetState(GameState state)
    {
        Currentstate = state;
    }
}
