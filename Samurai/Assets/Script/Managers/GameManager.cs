using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameState currentstate;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    public void SetState(GameState state)
    {
        currentstate = state;
    }
}
