using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSI : MonoBehaviour
{

    private void Awake()
    {
        transform.Find("ButtonPlay").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.GameScene_SpaceInvaders);  };
        transform.Find("ButtonQuit").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.MenuScene_SpaceInvaders);  }; //Application.Quit();
        transform.Find("TxtHighscore").GetComponent<Text>().text = "MEILLEUR SCORE : " + ScoreSI.GetHighScore(0).ToString();
    }
}
