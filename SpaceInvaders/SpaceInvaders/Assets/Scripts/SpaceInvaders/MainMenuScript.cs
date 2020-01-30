using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{

    private void Awake()
    {
        transform.Find("mainSubMenu").GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        /*Boutons menu principal*/
        transform.Find("mainSubMenu").Find("playButton").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.GameScene_SpaceInvaders);  };
        transform.Find("mainSubMenu").Find("quitButton").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.MenuScene_SpaceInvaders);  }; //Application.Quit();

        transform.Find("mainSubMenu").Find("highscore").GetComponent<Text>().text = "HIGHSCORE : " + ScoreSpaceInvaders.GetHighScore(0).ToString();

        transform.Find("mainSubMenu").gameObject.SetActive(true);
    }
}
