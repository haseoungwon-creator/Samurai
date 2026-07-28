using System.Collections;
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
        StartCoroutine(StartDelay());
    }

    void EnableInput()
    {
        isInputEnabled = true;
    }

    void Update()
    {
        if (isInputEnabled && Input.GetKeyDown(KeyCode.Space)&& hasPressedStart)
        {
            SceneryManager.Instance.LoadScene(nextSceneName);
            AudioManager.Instance.StopBgm();
            hasPressedStart = false;
        }
    }

    IEnumerator StartDelay()
    {
        yield return CoroutineManager.Wait(delay);
        isInputEnabled = true;
    }
}