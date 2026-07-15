using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;

    public void Pause()
    {
        Time.timeScale = 0;
        PanelManaager.Instance.Open(panel.Pause);

        pausePanel.SetActive(true);

        Debug.Log(pausePanel.activeInHierarchy);
    }

    public void Continue()
    {
        Debug.Log("Continue");
        Time.timeScale = 1f;
        GameManager.Instance.SetState(GameState.Playing);
        pausePanel.SetActive(false);
    }

    public void GoToMenu()
    {
        Debug.Log("GoToMenu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("StartTitle");
    }

    public void Quit()
    {
        Debug.Log("Quit");
    }

}