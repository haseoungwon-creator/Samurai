using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;

    MouseManager mouseManager;

    bool isOpen;

    private void Awake()
    {
        mouseManager = FindAnyObjectByType<MouseManager>();
    }

    public void Pause()
    {
        if (isOpen) return;

        isOpen = true;

        GameManager.Instance.SetState(GameState.Pause);

        Time.timeScale = 0f;

        SoundManager.Instance.PauseBGM();

        mouseManager.ShowCursor();

        pausePanel.SetActive(true);
    }

    public void Continue()
    {
        if (!isOpen) return;

        isOpen = false;

        GameManager.Instance.SetState(GameState.Playing);

        Time.timeScale = 1f;

        SoundManager.Instance.ResumeBGM();

        pausePanel.SetActive(false);

        mouseManager.HideCursor();
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
        
    }
}