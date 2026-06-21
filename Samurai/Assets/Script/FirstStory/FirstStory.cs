using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstStory : MonoBehaviour
{
    [SerializeField] AudioSource fireBgm;
    [SerializeField] AudioSource heartbit;
    [SerializeField]StoryManager storyManager;
    [SerializeField] AudioManager audioManager;

    private Text storybox;

    float textspeed = 0.2f;
    public int index;
    

    string[] storytext =
        {
            "난세의 불꽃이 온 세상을 집어삼키던 날",
            "사원의 검은 꺾였고, 스승의 서약은 잿더미가 되었다.",
            "살아남은 자에게 허락된 것은 오직 복수의 잔향뿐..."
        };

    private void Start()
    {
        audioManager.PlayBgm(fireBgm);
        storybox = GetComponent<Text>();
        index = 0;

        storyManager.StartTyping(storytext[0], storybox, textspeed);
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (storyManager.isTyping)
            {
                storyManager.skip(storytext[index], storybox);
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
        if(index < storytext.Length)
        {
            storyManager.StartTyping(storytext[index], storybox, textspeed);
        }

        else
        {
            StartCoroutine(audioManager.EndingAuido(fireBgm, heartbit, 2f, false));
        }
    }
   
   
}
