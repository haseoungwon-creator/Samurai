using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstStory : MonoBehaviour
{
    [SerializeField] AudioSource fireBgm;
    [SerializeField] AudioSource heartbit;

    [SerializeField] Text storyText;

    [SerializeField] float textSpeed = 0.05f;
    [SerializeField] string nextScene = "Village";

    private bool isEnding;
    private int index;
    

    private  readonly string[] introStory =
        {
            "난세의 불꽃이 온 세상을 집어삼키던 날",
            "사원의 검은 꺾였고, 스승의 서약은 잿더미가 되었다.",
            "살아남은 자에게 허락된 것은 오직 복수의 잔향뿐..."
        };

    private void Start()
    {
        GameManager.Instance.SetState(GameState.Story);
        AudioManager.Instance.PlayBgm(fireBgm);
        StoryManager.Instance.StartTyping(introStory[index],storyText,textSpeed);
        index = 0;

    }
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space))
            return;

        if (isEnding)
            return;

        if (StoryManager.Instance.isTyping)
        {
            StoryManager.Instance.Skip(storyText, introStory[index]);
        }
        else
        {
            NextLine();
        }
    }

    private void NextLine()
    {
        index++;

        if (index >= introStory.Length)
        {
            StartCoroutine(EndingRoutine());
            return;
        }

        StoryManager.Instance.StartTyping(introStory[index], storyText, textSpeed);
    }

    private IEnumerator EndingRoutine()
    {
        isEnding = true;

        StoryManager.Instance.StopTyping();

        FadeManager.Instance.FadeIn(0.5f);

        yield return new WaitForSeconds(0.5f);

        AudioManager.Instance.StopBgm();

        if (heartbit != null)
            AudioManager.Instance.PlayEffect(heartbit);

        GameManager.Instance.SetState(GameState.Playing);

        SceneryManager.Instance.LoadScene(nextScene);
    }

    private void OnDestroy()
    {
        if (StoryManager.Instance != null)
            StoryManager.Instance.StopTyping();
    }




}
