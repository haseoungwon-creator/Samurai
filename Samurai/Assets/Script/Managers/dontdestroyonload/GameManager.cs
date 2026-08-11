using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameState CurrentState { get; private set; } = GameState.None;

    public string CurrentScene { get; private set; }

    public GameObject Player { get; private set; }

    public event Action<GameState> OnStateChanged;
    public int PlayerHp {  get; private set; }

    protected override void Awake()
    {
        base.Awake();

        CurrentScene = SceneManager.GetActiveScene().name;

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    protected override void OnDestroy()
    {
        if(Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        base.OnDestroy();
    }

    private void OnSceneLoaded(Scene scene,LoadSceneMode mode)
    {
        CurrentScene = scene.name;
    }

    public void SetState(GameState newState)
    {
        if (CurrentState == newState) return;

        CurrentState = newState;

        OnStateChanged?.Invoke(CurrentState);
    }

    public void SetPlayer(GameObject player)
    {
        Player = player;
    }

    public void ClearPlayer()
    {
        Player = null;
    }

    public void SetPlayerHP(int hp)
    {
        PlayerHp = hp;
    }

    public void SetInitialPlauerHp(int maxHP)
    {
        if(PlayerHp <= 0)
            PlayerHp = maxHP;
    }

    public void ResetPlayerHP(int maxHP)
    {
        PlayerHp = maxHP;
    }
}
