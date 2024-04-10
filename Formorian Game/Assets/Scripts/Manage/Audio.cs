using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    AudioSource audioSource;
    public AudioType audioType;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        AudioUpdate(); // update the audio to the current volume
    }
    public enum AudioType // if we want different sound types?
    {
        ambience,
        sfx,
        music
    }
    public void AudioUpdate() // update the audio volume
    {
        audioSource.volume = .15f; // * Settings.PullSetting(Settings.Option.volume)
        if (audioType == AudioType.music) {
            audioSource.volume *= .25f;
        }
    }
}

