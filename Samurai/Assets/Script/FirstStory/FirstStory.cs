using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FirstStory : MonoBehaviour
{
    [SerializeField] AudioSource fireBgm;
    [SerializeField] AudioSource heartbit;
    bool isEndingTriggered = true;

    private Text storybox;

    float textspeed = 0.2f;
    public int index;
    

    string[] IntroStoryController =
        {
            "난세의 불꽃이 온 세상을 집어삼키던 날",
            "사원의 검은 꺾였고, 스승의 서약은 잿더미가 되었다.",
            "살아남은 자에게 허락된 것은 오직 복수의 잔향뿐..."
        };

    private void Start()
    {
        GameManager.Instance.SetState(GameState.Story);
        FadeManager.Instance.FadeOut(0.1f);
        AudioManager.Instance.PlayBgm(fireBgm);
        storybox = GetComponent<Text>();
        index = 0;

        StoryManager.instance.StartTyping(IntroStoryController[0], storybox, textspeed);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (StoryManager.instance.isTyping)
            {
                StoryManager.instance.SkipTyping();
            }
            else
            {
                ShowNextLine();
            }
        }
    }

    void ShowNextLine()
    {
        index++;
        if (index < IntroStoryController.Length)
        {
            StoryManager.instance.StartTyping(IntroStoryController[index], storybox, textspeed);
        }

        else
        {
            if (isEndingTriggered)
            {
                StartCoroutine(FirstStoryEnding());
            }
        }
    }

    IEnumerator FirstStoryEnding()
    {
        FadeManager.Instance.FadeIn(0.1f);
        AudioManager.Instance.EndingAudio(heartbit, fireBgm, false);

        GameManager.Instance.SetState(GameState.Playing);

        yield return new WaitForSeconds(3f);

        SceneManager.LoadScene("Village");
        isEndingTriggered = false;
    }

    
   
   
}
