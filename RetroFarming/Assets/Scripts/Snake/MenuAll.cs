using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAll : MonoBehaviour
{

    private void Awake()
    {
        /*Boutons menu principal*/
        transform.Find("playButton").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.MenuSceneSnake); };
        transform.Find("quitButton").GetComponent<Button_UI>().ClickFunc = () => { Application.Quit(); };

        transform.gameObject.SetActive(true);
    }
}
