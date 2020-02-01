using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSI : MonoBehaviour
{

    private void Awake()
    {
        transform.Find("TxtHighscore").GetComponent<Text>().text = "MEILLEUR SCORE : " + ScoreSI.GetHighScore(0).ToString();
    }
}
