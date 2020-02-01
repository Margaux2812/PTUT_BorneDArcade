using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    //Scripts
    private PlayerController playerController;
    private Wave wave;
    private LivesSlots livesSlots;

    //Game
    private int score = 0;
    private Text txtScore;
    private Text txtHighScore;
    private int level = 0;
    private Text txtLevel;
    private int lives = 3;
    private float delayPhase = 3f;

    //Sound
    [SerializeField] private AudioClip[] audioClip = null;
    private AudioSource audiosource;

    //GS Score
    public int ScoreGame
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            txtScore.text = "SCORE < " + score + " >";
        }
    }

    //GS Level
    private int LevelGame
    {
        get
        {
            return level;
        }
        set
        {
            level = value;
            txtLevel.text = "NIVEAU " + (level + 1);
        }
    }

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        wave = GameObject.Find("Wave").GetComponent<Wave>();
        livesSlots = GameObject.Find("TxtLives").GetComponent<LivesSlots>();
        txtLevel = GameObject.Find("TxtLevel").GetComponent<Text>();
        txtScore = GameObject.Find("TxtScore").GetComponent<Text>();
        txtHighScore = GameObject.Find("TxtHighScore").GetComponent<Text>();
        txtHighScore.text = "MEILLEUR SCORE < " + ScoreSI.GetHighScore(0).ToString() + " >";
    }

    //Lose level of the game (-1 life)
    public void Lose()
    {
        wave.StopWave();
        lives -= 1;
        livesSlots.LoseLivesSlot(lives);
        if(lives > 0)
        {
            StartCoroutine(GameRestart());
        }
        else
        {
            GameOver();
        }
    }

    //Win level of the game
    public void Win()
    {
        audiosource.Stop();
        audiosource.PlayOneShot(audioClip[0]);
        StartCoroutine(GameNextLevel());
    }

    //Game over (no more lives)
    private void GameOver()
    {
        audiosource.Stop();
        audiosource.PlayOneShot(audioClip[1]);
        GameOverSI.ShowStatic();
    }

    //Restart game
    private IEnumerator GameRestart()
    {
        yield return new WaitForSeconds(delayPhase);
        playerController.PlayerInitialise();
        wave.RestartWave();
    }

    //Next level of the game
    private IEnumerator GameNextLevel()
    {
        yield return new WaitForSeconds(delayPhase);
        audiosource.Play();
        LevelGame += 1;
        int levelMod = (level % 4);
        wave.WaveGenerator(levelMod, level);
        wave.RestartWave();
    }
}
