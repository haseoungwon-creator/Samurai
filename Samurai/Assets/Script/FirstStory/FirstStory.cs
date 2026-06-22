using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class FirstStory : MonoBehaviour
{
    [SerializeField] AudioSource fireBgm;
    [SerializeField] AudioSource heartbit;
    bool spacebarEndingOneClick = true;

    private Text storybox;

    float textspeed = 0.2f;
    public int index;
    

    string[] firststorytext =
        {
            "난세의 불꽃이 온 세상을 집어삼키던 날",
            "사원의 검은 꺾였고, 스승의 서약은 잿더미가 되었다.",
            "살아남은 자에게 허락된 것은 오직 복수의 잔향뿐..."
        };

    private void Start()
    {
        GameManager.instance.SetState(GameState.Story);
        FadeManager.instance.FadeOut(0.1f);
        AudioManager.instance.PlayBgm(fireBgm);
        storybox = GetComponent<Text>();
        index = 0;

        StoryManager.instance.StartTyping(firststorytext[0], storybox, textspeed);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (StoryManager.instance.isTyping)
            {
                StoryManager.instance.skip();
            }
            else
            {
                NextLine();
            }
        }
    }

    void NextLine()
    {
        index++;
        if (index < firststorytext.Length)
        {
            StoryManager.instance.StartTyping(firststorytext[index], storybox, textspeed);
        }

        else
        {
            if (spacebarEndingOneClick)
            {
                FadeManager.instance.FadeIn(0.1f);
                AudioManager.instance.EndingAudio(heartbit, fireBgm, false);

                GameManager.instance.SetState(GameState.Playing);

                spacebarEndingOneClick = false;
            }
        }
    }
   
   
}
