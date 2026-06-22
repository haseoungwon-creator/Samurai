using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] string nextSceneName = "";
    [SerializeField]FadeManager fadeManager;
    [SerializeField] AudioManager audioManager;
    [SerializeField] AudioSource audioSource;
    float delay = 1f;
    bool canInput = false;
    bool onetouch = true;

    void Start()
    {
        audioManager.PlayBgm(audioSource);
        Invoke("EnableInput", delay);
    }

    void EnableInput()
    {
        canInput = true;
    }

    void Update()
    {
        if (canInput && Input.GetKeyDown(KeyCode.Space)&& onetouch)
        {
            fadeManager.FadeIn();
            Invoke("NextScene", 3f);
            audioManager.StopBgm();
            onetouch = false;
           
            
        }
    }

    private void NextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}