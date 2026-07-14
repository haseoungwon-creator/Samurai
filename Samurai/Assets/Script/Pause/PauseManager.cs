using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;

    private void Awake()
    {
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { 
            if(GameManager.Instance.Currentstate == GameState.Playing)
                Pause();
                
            else if (GameManager.Instance.Currentstate == GameState.Pause)
                Continue();
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        GameManager.Instance.SetState(GameState.Pause);
        pausePanel.SetActive(true);
    }

    public void Continue()
    {
        Time.timeScale = 1f;
        GameManager.Instance.SetState(GameState.Playing);
        pausePanel.SetActive(false);
    }

    public void GoMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartTitle");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void TestClick()
    {
        Debug.Log("¹öÆ° Å¬¸¯µÊ");
    }
}