﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Score
{

   public static int GetHighScore(int index = 0)
    {
        switch (index)
        {
            case 0:
                return PlayerPrefs.GetInt("highscore", 0);
            case 1:
                return PlayerPrefs.GetInt("highscore2", 0);
            case 2:
                return PlayerPrefs.GetInt("highscore3", 0);
            case 3:
                return PlayerPrefs.GetInt("highscore4", 0);
            case 4:
                return PlayerPrefs.GetInt("highscore5", 0);
            default: return PlayerPrefs.GetInt("highscore", 0);
        }
    }

    public static string GetHighScorePseudo(int index = 0)
    {
        switch (index)
        {
            case 0:
                return PlayerPrefs.GetString("highscorePseudo", "Baptiste");
            case 1:
                return PlayerPrefs.GetString("highscore2Pseudo", "Baptiste");
            case 2:
                return PlayerPrefs.GetString("highscore3Pseudo", "Baptiste");
            case 3:
                return PlayerPrefs.GetString("highscore4Pseudo", "Baptiste");
            case 4:
                return PlayerPrefs.GetString("highscore5Pseudo", "Baptiste");
            default: return PlayerPrefs.GetString("highscorePseudo", "Baptiste");
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
                PlayerPrefs.SetInt("highscore", score);
                PlayerPrefs.SetString("highscorePseudo", pseudo);
                break;
            case 1:
                PlayerPrefs.SetInt("highscore2", score);
                PlayerPrefs.SetString("highscore2Pseudo", pseudo);
                break;
            case 2:
                PlayerPrefs.SetInt("highscore3", score);
                PlayerPrefs.SetString("highscore3Pseudo", pseudo);
                break;
            case 3:
                PlayerPrefs.SetInt("highscore4", score);
                PlayerPrefs.SetString("highscore4Pseudo", pseudo);
                break;
            case 4:
                PlayerPrefs.SetInt("highscore5", score);
                PlayerPrefs.SetString("highscore5Pseudo", pseudo);
                break;
            default: break;
        }
    }

    public static void updateHighscore(int score)
    {

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
            swap(indexToSwitch, score);
        }

        PlayerPrefs.Save();
    }

    public static void swap(int index, int newscore)
    {
        int lastScore = GetHighScore(index);
        SetHighScore("Margaux", index, newscore);
        int tmp;

        for (int i=index+1; i<5; i++)
        {
            tmp = GetHighScore(i);
            SetHighScore("Margaux", i, lastScore);
            lastScore = tmp;
        }
    }

    public static void reInitialize()
    {
        PlayerPrefs.SetInt("highscore" , 0);
        PlayerPrefs.SetInt("highscore2", 0);
        PlayerPrefs.SetInt("highscore3", 0);
        PlayerPrefs.SetInt("highscore4", 0);
        PlayerPrefs.SetInt("highscore5", 0);
        PlayerPrefs.Save();
    }
}