using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour
{
    private static GameHandler instance;

    private static int score;
    private static float timer;
    private static bool easterEgg;
    [SerializeField] private SnakeMovement snake;

    private LevelGrid levelGrid;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
        InitializeScore();
        Time.timeScale = 1f;
    }

    private void Start()
    {
        levelGrid = new LevelGrid(35, 24);

        snake.Setup(levelGrid);
        levelGrid.Setup(snake);
    }

    private static void InitializeScore()
    {
        score = 0;
    }

    public static int GetScore()
    {
        return score;
    }

    public static bool isSpecialMode()
    {
        return easterEgg;
    }

    public static float GetTime()
    {
        return timer;
    }

    public static void SetTime(float time)
    {
        timer = time;
    }

    public static void AddScore()
    {
        score += 100;
    }

    public void changeBg()
    {
        transform.Find("Background_img").GetComponent<SpriteRenderer>().sprite = GameAssets.instance.backgroundEasterEgg;
    }

    public static void removePoussins()
    {
        Object[] allObjects = FindObjectsOfType(typeof(GameObject));
        foreach (GameObject obj in allObjects)
        {
            if (obj.transform.name == "Poussin")
            {
                Destroy(obj);
            }
        }
        instance.changeBg();
    }

    public static void SnakeDied()
    {
        instance.transform.Find("Main Camera").GetComponent<AudioSource>().Stop();
        GameOverWindow.ShowStatic();
    }

    
}
