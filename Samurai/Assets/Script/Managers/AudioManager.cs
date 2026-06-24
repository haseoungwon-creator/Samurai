using System.Collections;
using UnityEngine;
using static UnityEditor.MaterialProperty;

public class AudioManager : Singleton<AudioManager>
{
    private AudioSource bgmSource;
    private AudioSource effectSource;
    private AudioSource sfxSource;

    protected override void Awake()
    {
        base.Awake();

        bgmSource = gameObject.AddComponent<AudioSource>();
        effectSource = gameObject.AddComponent<AudioSource>();
        sfxSource = gameObject.AddComponent<AudioSource>();

        bgmSource.loop = true;
        effectSource.loop = false;
        sfxSource.loop = false;
    }

    private void PlayAudio(AudioSource target, AudioSource source, bool loop)
    {
        if (source == null || target == null || source.clip == null) return;

        target.clip = source.clip;
        target.loop = loop;
        target.Play();
    }

    public void PlayBgm(AudioSource source)
    {
        PlayAudio(bgmSource, source, true);
    }

    public void StopBgm()
    {
        if(bgmSource == null) return;
        bgmSource.Stop();
    }


    public void PlayEffect(AudioSource source)
    {
        PlayAudio(effectSource, source, false);
    }

    public void StopEffect()
    {
        if (effectSource == null) return;
        effectSource.Stop();
    }


    public void PlaySfx(AudioSource source)
    {
        PlayAudio(sfxSource, source, false);
    }

    public void StopSfx()
    {
        if (sfxSource == null) return;
        sfxSource.Stop();
    }






}
