using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerMain : MonoBehaviour
{
    static AudioSource audioSource;

    public enum Sound
    {
        select,
        click
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(Sound sound)
    {
        if(audioSource != null)
            audioSource.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach (SoundAssets.SoundAudioClip soundAudioClip in SoundAssets.instance.soundAudioClips)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }

        return null;
    }
}
