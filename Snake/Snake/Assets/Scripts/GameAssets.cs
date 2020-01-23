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
    
    public Animator Chick;

    public Sprite poussinH;
    public Sprite poussinB;
    public Sprite poussinG;
    public Sprite poussinD;
    public Sprite snakeFoodSprite;

    public SoundAudioClip[] soundAudioClips;

    [Serializable]
    public class SoundAudioClip
    {
        public SoundsManager.Sound sound;
        public AudioClip audioClip;
    }
}
