using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RankingScreen : MonoBehaviour
{
    private static RankingScreen instance;

    private void Awake()
    {
        instance = this;

        Show();
    }

    private void Show()
    {
        //Play sound
        //SoundsManager.PlaySound(SoundsManager.Sound.gameOver);

        string spaceInvadersPseudo = "";
        string spaceInvadersScore = "";
        string snakePseudo = "";
        string snakeScore = "";
        string pseudo= "";

        for(int i=0; i<10; i++)
        {
            pseudo = Score.GetHighScorePseudo(i);
            if (pseudo.Length != 10)
            {
                for (int j = pseudo.Length; j <= 10; j++)
                {
                    pseudo += " ";
                }
            }
            snakePseudo += (i+1) + ". " + pseudo + System.Environment.NewLine;
        }
        for (int i = 0; i < 10; i++)
        {
            snakeScore += Score.GetHighScore(i) + System.Environment.NewLine;
        }

        for (int i = 0; i < 10; i++)
        {
            //pseudo = Score.GetHighScorePseudo(i);
            if (pseudo.Length != 10)
            {
                pseudo = ScoreSI.GetHighScorePseudo(i);
                for (int j = pseudo.Length; j <= 10; j++)
                {
                    pseudo += " ";
                }
            }
            spaceInvadersPseudo += (i + 1) + ". " + pseudo + System.Environment.NewLine;
        }
        for (int i = 0; i < 10; i++)
        {
            spaceInvadersScore += ScoreSI.GetHighScore(i) + System.Environment.NewLine;
        }

        //Score Space Invader
        transform.Find("Ranking/SpaceInvadersRank/SpaceInvadersPseudo").GetComponent<Text>().text = spaceInvadersPseudo;
        transform.Find("Ranking/SpaceInvadersRank/SpaceInvadersScore").GetComponent<Text>().text = spaceInvadersScore;
        //Score snake
        transform.Find("Ranking/SnakeRank/SnakePseudo").GetComponent<Text>().text = snakePseudo;
        transform.Find("Ranking/SnakeRank/SnakeScore").GetComponent<Text>().text = snakeScore;

        gameObject.SetActive(true);
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    public static void ShowStatic()
    {
        instance.Show();
    }
}
