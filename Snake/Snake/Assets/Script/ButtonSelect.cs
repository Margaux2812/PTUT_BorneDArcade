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

    public GameObject[] ButtonEffect = new GameObject[5];

    private void Start() {
        ButtonEffect[0].GetComponent<Button>().Select();
        ButtonEffect[3].GetComponent<TextEffect1>().enabled = true;
        ButtonBuf = ButtonEffect[3];

        EventSystemObj = GameObject.Find("EventSystem");
        rank = EventSystemObj.GetComponent<BoolFlag>();
        rankTmp = rank.getfRank();
    }

    void Update() {
        Button = EventSystem.current.currentSelectedGameObject;
        //Debug.Log(Button);

        for (int i=0; i<ButtonEffect.Length;  i++) {
            if ((Button == ButtonEffect[i]) && (Button != ButtonBuf)) {
                ButtonEffect[i].GetComponent<TextEffect1>().enabled = true;

                TextEffect1 buf = ButtonBuf.GetComponent<TextEffect1>();
                buf.ResetColor();
                buf.enabled = false;

                ButtonBuf = Button;
            }
        }

        if (rank.getfRank()) {
            ButtonEffect[4].GetComponent<Button>().Select();
            rankTmp = rank.getfRank();
        } else {
            if (rankTmp != rank.getfRank()) {
                ButtonEffect[3].GetComponent<Button>().Select();
                rankTmp = rank.getfRank();
            }
        }
    }
}
