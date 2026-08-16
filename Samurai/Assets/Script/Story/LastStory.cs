using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LastStory : MonoBehaviour
{
    [SerializeField] private Text storyText;
    [SerializeField] private float textSpeed = 0.8f;
    [SerializeField] private float fadeDuration = 0.5f;

    private bool isEnding;
    private bool isFading;
    private int index;

    private readonly string[] introStory =
    {
        "검기가 도달한 칼끝의 주인이 사원을 노리던 마물이 아님을 깨달았던 그 순간.",
        "부스러진 고향의 자취와 핏빛으로 물든 노리개는 잔혹한 진실을 속삭였다.",
        "모든 환영이 걷히고 마침내 드러난 참극의 끝에 홀로 남겨진 자여.",
        "단죄의 끝에 남은 것은 영웅이 아닌 악귀였다.",
        "스스로 눈을 가린 자여, 이제 영원히 꺼지지 않을 잿더미 속에서 눈을 떠라."
    };

    private void Start()
    {
        index = 0;
        isEnding = false;
        isFading = false;

        GameManager.Instance.SetState(GameState.Story);
        StoryManager.Instance.StartTyping(introStory[index], storyText, textSpeed);
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Space) || isEnding || isFading)
            return;

        if (StoryManager.Instance.isTyping)
        {
            StoryManager.Instance.Skip(storyText, introStory[index]);
        }
        else
        {
            StartCoroutine(NextLineWithFade());
        }
    }

    private IEnumerator NextLineWithFade()
    {
        isFading = true;
        index++;

        if (index < introStory.Length)
        {
            yield return StartCoroutine(FadeText(1f, 0f));
            storyText.color = new Color(storyText.color.r, storyText.color.g, storyText.color.b, 1f);
            StoryManager.Instance.StartTyping(introStory[index], storyText, textSpeed);
        }
        else
        {
            isEnding = true;
            yield return StartCoroutine(FadeText(1f, 0f));
            GoToTitle();
        }

        isFading = false;
    }

    private IEnumerator FadeText(float startAlpha, float targetAlpha)
    {
        float elapsedTime = 0f;
        Color color = storyText.color;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, targetAlpha, elapsedTime / fadeDuration);
            storyText.color = new Color(color.r, color.g, color.b, newAlpha);
            yield return null;
        }

        storyText.color = new Color(color.r, color.g, color.b, targetAlpha);
    }

    private void GoToTitle()
    {
        WorldManager.Instance?.ResetWorld();
        GoldManager.Instance?.ResetGold();
        QuestManager.Instance?.ResetAllQuests();
        Inventory.Instance?.ResetInventory();
        PlayerStat.Instance?.ResetStat();
        PlayerStateMachine.Instance?.ResetState();
        NPCManager.Instance?.ResetAllTalk();
        GameManager.Instance?.ClearPlayer();
        GameManager.Instance?.ResetPlayerHP(0);
        MouseManager.Instance?.ResetMouse();

        SceneryManager.Instance.LoadScene("StartTitle");
    }
}