using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : Singleton<GameOverManager>
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Image darkImage;
    [SerializeField] Text gameOverText;
    [SerializeField] Image[] buttonImages;
    [SerializeField] Text[] buttonTexts;
    [SerializeField] float darkDuration = 2f;
    [SerializeField] float textSpeed = 0.5f;
    [SerializeField] float buttonFadeDuration = 0.5f;

    bool isShowing;

    protected override void Awake()
    {
        base.Awake();

        if (Instance != this)
            return;

        SceneManager.sceneLoaded += OnSceneLoaded;
        ResetUI();
    }

    protected override void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        base.OnDestroy();
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (this == null)
            return;

        StopAllCoroutines();

        isShowing = false;

        ResetUI();

        if (MouseManager.Instance != null)
            MouseManager.Instance.HideCursor();
    }

    void ResetUI()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (darkImage != null)
        {
            Color color = darkImage.color;
            color.a = 0f;
            darkImage.color = color;
            darkImage.raycastTarget = false;
        }

        if (gameOverText != null)
        {
            Color color = gameOverText.color;
            color.a = 1f;
            gameOverText.color = color;
            gameOverText.text = "";
        }

        SetButtonsAlpha(0f);
        SetButtonsInteractable(false);
    }

    public void ShowGameOver()
    {
        if (isShowing)
            return;

        if (gameOverPanel == null)
            return;

        if (GameManager.Instance == null)
            return;

        isShowing = true;

        GameManager.Instance.SetState(GameState.GameOver);

        if (MouseManager.Instance != null)
        {
            MouseManager.Instance.ShowCursor();
        }
        else
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

        gameOverPanel.SetActive(true);

        StartCoroutine(GameOverRoutine());
    }

    IEnumerator GameOverRoutine()
    {
        yield return StartCoroutine(DarkenScreen());

        if (StoryManager.Instance != null && gameOverText != null)
        {
            StoryManager.Instance.StartTyping(
                "Game Over YOU DIE",
                gameOverText,
                textSpeed
            );

            while (StoryManager.Instance.isTyping)
                yield return null;
        }

        yield return StartCoroutine(FadeButtons());

        SetButtonsInteractable(true);
    }

    IEnumerator DarkenScreen()
    {
        if (darkImage == null)
            yield break;

        darkImage.raycastTarget = true;

        float time = 0f;
        Color color = darkImage.color;

        while (time < darkDuration)
        {
            time += Time.deltaTime;

            color.a = Mathf.Lerp(
                0f,
                1f,
                time / darkDuration
            );

            darkImage.color = color;

            yield return null;
        }

        color.a = 1f;
        darkImage.color = color;
    }

    IEnumerator FadeButtons()
    {
        float time = 0f;

        while (time < buttonFadeDuration)
        {
            time += Time.deltaTime;

            float alpha = Mathf.Lerp(
                0f,
                1f,
                time / buttonFadeDuration
            );

            SetButtonsAlpha(alpha);

            yield return null;
        }

        SetButtonsAlpha(1f);
    }

    void SetButtonsAlpha(float alpha)
    {
        if (buttonImages != null)
        {
            foreach (Image image in buttonImages)
            {
                if (image == null)
                    continue;

                Color color = image.color;
                color.a = alpha;
                image.color = color;
            }
        }

        if (buttonTexts != null)
        {
            foreach (Text text in buttonTexts)
            {
                if (text == null)
                    continue;

                Color color = text.color;
                color.a = alpha;
                text.color = color;
            }
        }
    }

    void SetButtonsInteractable(bool value)
    {
        if (buttonImages == null)
            return;

        foreach (Image image in buttonImages)
        {
            if (image == null)
                continue;

            Button button = image.GetComponent<Button>();

            if (button != null)
                button.interactable = value;
        }
    }

    public void GoToTitle()
    {
        ResetGameData();

        isShowing = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (SceneryManager.Instance != null)
            SceneryManager.Instance.LoadScene("StartTitle");
    }

    void ResetGameData()
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
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}