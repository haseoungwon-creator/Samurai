using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] string nextSceneName = "";
    [SerializeField] AudioSource audioSource;
    float delay = 1f;
    bool isInputEnabled = false;
    bool hasPressedStart = true;

    void Start()
    {
        AudioManager.Instance.PlayBgm(audioSource);
        Invoke("EnableInput", delay);
    }

    void EnableInput()
    {
        isInputEnabled = true;
    }

    void Update()
    {
        if (isInputEnabled && Input.GetKeyDown(KeyCode.Space)&& hasPressedStart)
        {
            FadeManager.Instance.FadeIn(2f);
            Invoke("LoadNextScene", 3f);
            AudioManager.Instance.StopBgm();
            hasPressedStart = false;
           
            
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}