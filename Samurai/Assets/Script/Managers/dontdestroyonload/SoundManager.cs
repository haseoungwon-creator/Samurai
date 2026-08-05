using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : Singleton<SoundManager>
{
    [SerializeField] AudioSource effectAudioSource;
    [SerializeField] AudioSource sceneryAudioSource;

    [SerializeField] float fadeTime = 0.5f;
    [SerializeField] Dictionary<Sound, AudioClip> dictionary;

    Coroutine bgmCoroutine;

    private void Start()
    {
        dictionary = new Dictionary<Sound, AudioClip>();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void Emit(Sound name)
    {
        if (!dictionary.TryGetValue(name, out AudioClip clip))
        {
            clip = Resources.Load<AudioClip>("Audios/" + name);

            if (clip == null)
            {
                Debug.LogWarning($"Audio not found : {name}");
                return;
            }

            dictionary.Add(name, clip);
        }

        effectAudioSource.PlayOneShot(clip);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioClip nextClip = Resources.Load<AudioClip>("Audios/" + scene.name);

        if (nextClip == null)
            return;

        if (bgmCoroutine != null)
            StopCoroutine(bgmCoroutine);

        bgmCoroutine = StartCoroutine(ChangeBGM(nextClip));
    }

    IEnumerator ChangeBGM(AudioClip nextClip)
    {
        float targetVolume = 0.25f;

        // Fade Out
        while (sceneryAudioSource.volume > 0f)
        {
            sceneryAudioSource.volume -= Time.deltaTime / fadeTime;

            if (sceneryAudioSource.volume < 0f)
                sceneryAudioSource.volume = 0f;

            yield return null;
        }

        sceneryAudioSource.Stop();

        sceneryAudioSource.clip = nextClip;
        sceneryAudioSource.volume = 0f;
        sceneryAudioSource.Play();

        // Fade In
        while (sceneryAudioSource.volume < targetVolume)
        {
            sceneryAudioSource.volume += Time.deltaTime / fadeTime;

            if (sceneryAudioSource.volume > targetVolume)
                sceneryAudioSource.volume = targetVolume;

            yield return null;
        }

        bgmCoroutine = null;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    public void PauseBGM()
    {
        sceneryAudioSource.Pause();
    }

    public void ResumeBGM()
    {
        sceneryAudioSource.UnPause();
    }
}