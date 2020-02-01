using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolFlag : MonoBehaviour{
    // private
    private bool fRank;

    public bool getfRank() {
        return fRank;
    }

    public void setfRank() {
        fRank=!fRank;
    }
}
