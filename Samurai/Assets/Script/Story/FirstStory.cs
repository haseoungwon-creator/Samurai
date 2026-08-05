using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstStory : MonoBehaviour
{
    [SerializeField] Text storyText;

    [SerializeField] float textSpeed = 2f;
    [SerializeField] string nextScene = "Village";

    private bool isEnding;
    private int index;
    

    private  readonly string[] introStory =
        {
            "난세의 붉은 불꽃이 사원의 하늘과 온 세상을 집어삼키던 그 밤.",
            "스승의 엄숙했던 가르침은 꺾였고, 다정했던 친구와의 서약은 잿더미 속에 스러졌다.",
            "모든 것이 타버린 잿더미 속에 홀로 살아남은 자에게 허락된 것은...",
            "지울 수 없는 핏빛 기억과 오직 깊은 죄책감의 잔향뿐이었다."
        };

    private void Start()
    {
        GameManager.Instance.SetState(GameState.Story);
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

        SoundManager.Instance.Emit(Sound.HeavyHeartBeat);

        GameManager.Instance.SetState(GameState.Playing);

        SceneryManager.Instance.LoadScene(nextScene);
    }

    private void OnDestroy()
    {
        if (StoryManager.Instance != null)
            StoryManager.Instance.StopTyping();
    }




}
