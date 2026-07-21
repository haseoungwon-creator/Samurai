using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseManager :MonoBehaviour
{
    [SerializeField] GameObject pausePanel;

    bool isOpen = false;
    public void Pause()
    {
        if (isOpen) return;
        isOpen = true;
        Time.timeScale = 0;
        MouseManager.Instance.ShowCursor();
        pausePanel.SetActive(true);

        Debug.Log(pausePanel.activeInHierarchy);
    }

    public void Continue()
    {
        isOpen = false;
        Debug.Log("Continue");
        Time.timeScale = 1f;
        GameManager.Instance.SetState(GameState.Playing);
        pausePanel.SetActive(false);
        MouseManager.Instance.HideCursor();
    }

    public void GoToMenu()
    {
        isOpen = false;
        Debug.Log("GoToMenu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartTitle");
        pausePanel.SetActive(false );
        MouseManager.Instance.HideCursor();
    }

    public void Quit()
    {
        isOpen = false;
        Debug.Log("Quit");
    }

}