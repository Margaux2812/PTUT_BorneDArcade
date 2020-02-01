using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    
    private void Awake()
    {
        transform.Find("TxtHighscore").GetComponent<Text>().text = "MEILLEUR SCORE : " + Score.GetHighScore(0).ToString();
    }
}
