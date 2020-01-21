using CodeMonkey.Utils;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    private enum Sub{
        Main,
        Commandes
    }

    private void Awake()
    {
        transform.Find("commandesSubMenu").GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        transform.Find("mainSubMenu").GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

        /*Boutons menu principal*/
        transform.Find("mainSubMenu").Find("playButton").GetComponent<Button_UI>().ClickFunc = () => { Loader.Load(Loader.Scene.GameScene);  };
        transform.Find("mainSubMenu").Find("quitButton").GetComponent<Button_UI>().ClickFunc = () => { Application.Quit(); };
        transform.Find("mainSubMenu").Find("commandesButton").GetComponent<Button_UI>().ClickFunc = () => { ShowSub(Sub.Commandes); };

        /*Boutons Commandes*/
        transform.Find("commandesSubMenu").Find("backButton").GetComponent<Button_UI>().ClickFunc = () => { ShowSub(Sub.Main); };

        ShowSub(Sub.Main);
    }

    private void ShowSub(Sub sub)
    {
        transform.Find("mainSubMenu").gameObject.SetActive(false);
        transform.Find("commandesSubMenu").gameObject.SetActive(false);

        switch (sub)
        {
            case Sub.Main:
                transform.Find("mainSubMenu").gameObject.SetActive(true);
                break;
            case Sub.Commandes:
                transform.Find("commandesSubMenu").gameObject.SetActive(true);
                break;
        }
    }
}
