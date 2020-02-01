using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundAssets : MonoBehaviour
{
    public static SoundAssets instance;

    private void Awake()
    {
        instance = this;
    }

    public SoundAudioClip[] soundAudioClips;

    [Serializable]
    public class SoundAudioClip
    {
        public SoundManagerMain.Sound sound;
        public AudioClip audioClip;
    }
}
