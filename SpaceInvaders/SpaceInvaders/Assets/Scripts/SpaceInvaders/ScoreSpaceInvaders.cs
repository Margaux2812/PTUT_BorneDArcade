using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreSpaceInvaders
{

   public static int GetHighScore(int index = 0)
    {
        switch (index)
        {
            case 0:
                return PlayerPrefs.GetInt("siHighscore", 0);
            case 1:
                return PlayerPrefs.GetInt("siHighscore2", 0);
            case 2:
                return PlayerPrefs.GetInt("siHighscore3", 0);
            case 3:
                return PlayerPrefs.GetInt("siHighscore4", 0);
            case 4:
                return PlayerPrefs.GetInt("siHighscore5", 0);
            case 5:
                return PlayerPrefs.GetInt("siHighscore6", 0);
            case 6:
                return PlayerPrefs.GetInt("siHighscore7", 0);
            case 7:
                return PlayerPrefs.GetInt("siHighscore8", 0);
            case 8:
                return PlayerPrefs.GetInt("siHighscore9", 0);
            case 9:
                return PlayerPrefs.GetInt("siHighscore10", 0);
            default: return PlayerPrefs.GetInt("siHighscore", 0);
        }
    }

    public static string GetHighScorePseudo(int index = 0)
    {
        switch (index)
        {
            case 0:
                return PlayerPrefs.GetString("siHighscorePseudo", "Utilisateur inconnu");
            case 1:
                return PlayerPrefs.GetString("sHighscore2Pseudo", "Utilisateur inconnu");
            case 2:
                return PlayerPrefs.GetString("sHighscore3Pseudo", "Utilisateur inconnu");
            case 3:
                return PlayerPrefs.GetString("sHighscore4Pseudo", "Utilisateur inconnu");
            case 4:
                return PlayerPrefs.GetString("sHighscore5Pseudo", "Utilisateur inconnu");
            case 5:
                return PlayerPrefs.GetString("sHighscore6Pseudo", "Utilisateur inconnu");
            case 6:
                return PlayerPrefs.GetString("sHighscore7Pseudo", "Utilisateur inconnu");
            case 7:
                return PlayerPrefs.GetString("sHighscore8Pseudo", "Utilisateur inconnu");
            case 8:
                return PlayerPrefs.GetString("sHighscore9Pseudo", "Utilisateur inconnu");
            case 9:
                return PlayerPrefs.GetString("sHighscore10Pseudo", "Utilisateur inconnu");
            default: return PlayerPrefs.GetString("siHighscorePseudo", "Utilisateur inconnu");
        }
    }

    public static int GetScore()
    {
        return PlayerPrefs.GetInt("actualScore", 0);
    }

    public static void SetHighScore(string pseudo, int index, int score)
    {
        switch (index)
        {
            case 0:
                PlayerPrefs.SetInt("siHighscore", score);
                PlayerPrefs.SetString("siHighscorePseudo", pseudo);
                break;
            case 1:
                PlayerPrefs.SetInt("siHighscore2", score);
                PlayerPrefs.SetString("siHighscore2Pseudo", pseudo);
                break;
            case 2:
                PlayerPrefs.SetInt("siHighscore3", score);
                PlayerPrefs.SetString("siHighscore3Pseudo", pseudo);
                break;
            case 3:
                PlayerPrefs.SetInt("siHighscore4", score);
                PlayerPrefs.SetString("siHighscore4Pseudo", pseudo);
                break;
            case 4:
                PlayerPrefs.SetInt("siHighscore5", score);
                PlayerPrefs.SetString("siHighscore5Pseudo", pseudo);
                break;
            default: break;
        }
        PlayerPrefs.Save();
    }

    public static void updateHighscore()
    {
        int score = PlayerPrefs.GetInt("score", 0);

        int indexToSwitch = -1;
        for (int i = 0; i < 5; i++)
        {
            int highscore = GetHighScore(i);
            if (score > highscore)
            {
                indexToSwitch = i;
                break;
            }
        }

        if (indexToSwitch != -1)
        {
            swap(indexToSwitch, score, PlayerPrefs.GetString("pseudo", "VOUS"));
        }

        PlayerPrefs.Save();
    }

    private static void changeVous(string pseudo)
    {
        for(int i=0; i<5; i++)
        {
            if(GetHighScorePseudo(i) == "VOUS")
            {
                SetHighScore(pseudo, i, GetHighScore(i));
            }
        }
        GameOverWindow.ShowStaticUpdated();
    }

    public static void setPseudo(string pseudo)
    {
        PlayerPrefs.SetString("pseudo", pseudo);
        changeVous(pseudo);
        PlayerPrefs.Save();
    }

    public static void setScore(int score)
    {
        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetString("pseudo", "VOUS");
        PlayerPrefs.Save();
    }

    public static void swap(int index, int newscore, string pseudo)
    {
        int lastScore = GetHighScore(index);
        string lastPseudo = GetHighScorePseudo(index);
        SetHighScore(pseudo, index, newscore);
        int tmp;
        string tmpPseudo;

        for (int i=index+1; i<5; i++)
        {
            tmp = GetHighScore(i);
            tmpPseudo = GetHighScorePseudo(i);
            SetHighScore(lastPseudo, i, lastScore);
            lastScore = tmp;
            lastPseudo = tmpPseudo;
        }
    }

    public static void reInitialize()
    {
        PlayerPrefs.SetInt("siHighscore" , 0);
        PlayerPrefs.SetInt("siHighscore2", 0);
        PlayerPrefs.SetInt("siHighscore3", 0);
        PlayerPrefs.SetInt("siHighscore4", 0);
        PlayerPrefs.SetInt("siHighscore5", 0);
        PlayerPrefs.SetInt("siHighscore6", 0);
        PlayerPrefs.SetInt("siHighscore7", 0);
        PlayerPrefs.SetInt("siHighscore8", 0);
        PlayerPrefs.SetInt("siHighscore9", 0);
        PlayerPrefs.SetInt("siHighscore10", 0);

        PlayerPrefs.SetString("siHighscorePseudo", ".....");
        PlayerPrefs.SetString("siHighscore2Pseudo", ".....");
        PlayerPrefs.SetString("siHighscore3Pseudo", ".....");
        PlayerPrefs.SetString("siHighscore4Pseudo", ".....");
        PlayerPrefs.SetString("siHighscore5Pseudo", ".....");
        PlayerPrefs.SetString("siHighscore6Pseudo", ".....");
        PlayerPrefs.SetString("siHighscore7Pseudo", ".....");
        PlayerPrefs.SetString("siHighscore8Pseudo", ".....");
        PlayerPrefs.SetString("siHighscore9Pseudo", ".....");
        PlayerPrefs.SetString("siHighscore10Pseudo", ".....");

        PlayerPrefs.Save();
    }
}
