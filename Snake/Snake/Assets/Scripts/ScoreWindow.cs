using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreWindow : MonoBehaviour
{
    private Text score;

    private void Awake()
    {
        score = transform.Find("Score").GetComponent<Text>();
    }

    private void Update()
    {
        score.text = GameHandler.GetScore().ToString();
    }
}
