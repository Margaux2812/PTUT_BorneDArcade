using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    public static GameAssets instance;

    private void Awake()
    {
        instance = this;
    }
  
    public Sprite snakeFoodSprite;

    public Animator poussin;

    public SoundAudioClip[] soundAudioClips;

    [Serializable]
    public class SoundAudioClip
    {
        public SoundsManager.Sound sound;
        public AudioClip audioClip;
    }
}
