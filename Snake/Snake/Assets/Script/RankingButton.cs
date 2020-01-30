using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RankingButton : MonoBehaviour{
    //public
    public GameObject FirstScreen;
    public GameObject RankingScreen;

    // private
    private GameObject EventSystem;
    private BoolFlag rank;

    private void Start() {
        EventSystem = GameObject.Find("EventSystem");
        rank = EventSystem.GetComponent<BoolFlag>();
    }

    public void rankingButtonEvent() {
        rank.setfRank();
    }

    private void Update() {
        if (rank.getfRank()) {
            FirstScreen.SetActive(false);
            RankingScreen.SetActive(true);
        }else {
            FirstScreen.SetActive(true);
            RankingScreen.SetActive(false);
        }
    }
}
