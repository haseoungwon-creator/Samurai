using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    [SerializeField] string nextSceneName = "";
    float delay = 1f;
    bool isInputEnabled = false;
    bool hasPressedStart = true;

    void Start()
    {
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
            hasPressedStart = false;
        }
    }

    IEnumerator StartDelay()
    {
        yield return CoroutineManager.Wait(delay);
        isInputEnabled = true;
    }
}