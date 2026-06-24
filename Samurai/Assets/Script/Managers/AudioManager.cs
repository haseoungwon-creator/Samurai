using System.Collections;
using UnityEngine;
using static UnityEditor.MaterialProperty;

public class AudioManager : Singleton<AudioManager>
{
    AudioSource bgmSource;
    AudioSource effectSource;
    AudioSource sfxSource;

    
    public void PlayBgm(AudioSource source)
    {
        bgmSource = source;
        bgmSource.loop = true;
        bgmSource.Play();
        return;
    }

    public void StopBgm()
    {
        bgmSource.Stop();
    }

    public void PlayEffect(AudioSource source)
    {
        effectSource = source;
        effectSource.loop = false;
        effectSource.Play();
    }


    public void PlaySfx(AudioSource source)
    {
        sfxSource = source;
        sfxSource.loop = false;
        sfxSource.Play();
    }

    public IEnumerator EndingAuido(AudioSource sourcestart,AudioSource sourceending,float stoptime,bool looptype)
    {
        sourceending.Stop();
        yield return new WaitForSeconds(stoptime);
        sourcestart.loop = looptype;
        sourcestart.Play();
    }

    public void EndingAudio(AudioSource sourcestart, AudioSource sourceending, bool looptype)
    {
        sourceending.Stop();
        sourcestart.loop = looptype;
        sourcestart.Play();
    }

    public IEnumerator EndingAuido(AudioSource sourcestart, float stoptime, bool looptype)
    {
        sourcestart.Stop();
        yield return new WaitForSeconds(stoptime);
        sourcestart.loop = looptype;
        sourcestart.Play();
    }

}
