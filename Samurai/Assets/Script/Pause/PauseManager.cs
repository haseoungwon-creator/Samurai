using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseManager :MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    MouseManager mouseManager;

    private void Awake()
    {
        mouseManager = FindAnyObjectByType<MouseManager>();
    }

    bool isOpen = false;
    public void Pause()
    {
        if (isOpen) return;
        isOpen = true;
        Time.timeScale = 0;
        mouseManager.ShowCursor();
        pausePanel.SetActive(true);
    }

    public void Continue()
    {
        isOpen = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        mouseManager.HideCursor();
        GameManager.Instance.SetState(GameState.Playing);
    }

    public void GoToMenu()
    {
        isOpen = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        mouseManager.HideCursor();
        SceneManager.LoadScene("StartTitle");
    }

    public void Quit()
    {
        isOpen = false;
        Debug.Log("Quit");
    }

}