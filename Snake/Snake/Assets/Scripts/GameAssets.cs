﻿using System.Collections;
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

    public AudioClip chickenMoves;
}
