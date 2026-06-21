using System.Collections;
using UnityEngine;
using static UnityEditor.MaterialProperty;

public class AudioManager : MonoBehaviour
{
    AudioSource BgmSource;
    AudioSource EffectSource;
    AudioSource sfxSource;

    public void PlayBgm(AudioSource source)
    {
        BgmSource = source;
        BgmSource.loop = true;
        BgmSource.Play();
        return;
    }

    public void StopBgm()
    {
        BgmSource.Stop();
    }

    public void PlayEffect(AudioSource source)
    {
        EffectSource = source;
        EffectSource.loop = false;
        EffectSource.Play();
    }


    public void PlaysfxSource(AudioSource source)
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

    public IEnumerator EndingAuido(AudioSource sourcestart, float stoptime, bool looptype)
    {
        sourcestart.Stop();
        yield return new WaitForSeconds(stoptime);
        sourcestart.loop = looptype;
        sourcestart.Play();
    }

}
