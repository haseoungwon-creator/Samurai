using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] string nextSceneName = "";
    [SerializeField] AudioSource audioSource;
    float delay = 1f;
    bool canInput = false;
    bool onetouch = true;

    void Start()
    {
        AudioManager.instance.PlayBgm(audioSource);
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
            FadeManager.instance.FadeIn(2f);
            Invoke("NextScene", 3f);
            AudioManager.instance.StopBgm();
            onetouch = false;
           
            
        }
    }

    private void NextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}