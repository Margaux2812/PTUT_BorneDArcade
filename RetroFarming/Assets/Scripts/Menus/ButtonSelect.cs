using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour{
    // private
    private GameObject Button;
    private GameObject ButtonBuf;
    private GameObject EventSystemObj;
    private BoolFlag rank;
    private bool rankTmp;
    private float timer;

    public GameObject[] ButtonEffect = new GameObject[4];

    private void Start() {
        ButtonEffect[0].GetComponent<Button>().Select();
        ButtonEffect[2].GetComponent<TextEffect1>().enabled = true;
        ButtonBuf = ButtonEffect[2];

        EventSystemObj = GameObject.Find("EventSystem");
        rank = EventSystemObj.GetComponent<BoolFlag>();
        rankTmp = rank.getfRank();
    }

    void Update() {
        Button = EventSystem.current.currentSelectedGameObject;
       

        for (int i=0; i<ButtonEffect.Length;  i++) {
            if ((Button == ButtonEffect[i]) && (Button != ButtonBuf)) {
                /*On change de bouton*/
                SoundManagerMain.PlaySound(SoundManagerMain.Sound.select);


                ButtonEffect[i].GetComponent<TextEffect1>().enabled = true;
                
                TextEffect1 buf = ButtonBuf.GetComponent<TextEffect1>();
                buf.ResetColor();
                buf.enabled = false;

                ButtonBuf = Button;
            }
        }

        if (rank.getfRank()) {
            ButtonEffect[3].GetComponent<Button>().Select();
            rankTmp = rank.getfRank();
        } else {
            if (rankTmp != rank.getfRank()) {
                ButtonEffect[2].GetComponent<Button>().Select();
                rankTmp = rank.getfRank();
            }
        }
        
    }
}
