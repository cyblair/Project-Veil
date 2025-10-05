using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance { get; private set; }

    private AudioSource source;

    private void Awake()
    {
        instance = this;

        source = GetComponent<AudioSource>();
    }
    int everyOther;
    public void PlaySound(AudioClip sound, float basePitch, float pitchRange)
    {
        everyOther += 1;
        if (everyOther > 2)
        {
            source.pitch = basePitch + Random.Range(-pitchRange, pitchRange);
            source.PlayOneShot(sound);
            everyOther = 0;
        }
    }

}
