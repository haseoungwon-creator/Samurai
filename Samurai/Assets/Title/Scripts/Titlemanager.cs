using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public string nextSceneName = "Aimation";

    float delay = 1f;
    bool canInput = false;

    void Start()
    {
        Invoke("EnableInput", delay);
    }

    void EnableInput()
    {
        canInput = true;
    }

    void Update()
    {
        if (canInput && Input.anyKeyDown)
        {
            Invoke("NextScene", 3f);
            
        }
    }

    private void NextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}