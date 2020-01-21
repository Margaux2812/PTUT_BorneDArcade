using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;

public class LevelGrid
{
    private Vector2Int foodPosition;
    private GameObject foodImg;
    private int width;
    private int height;
    private SnakeMovement snake;

    public LevelGrid(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void Setup(SnakeMovement snake)
    {
        this.snake = snake;

        SpawnFood();
    }

    private void SpawnFood()
    {
        do
        {
            foodPosition = new Vector2Int(Random.Range(1, width-1), Random.Range(1, height-1));
        } while (snake.GetListSnakePosition().IndexOf(foodPosition) != -1);

        foodImg = new GameObject("Food", typeof(SpriteRenderer));
        foodImg.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.snakeFoodSprite;
        foodImg.transform.position = new Vector3(foodPosition.x, foodPosition.y, 0);
    }

    public bool TryEatFood(Vector2Int snakePosition)
    {
        if(snakePosition == foodPosition)
        {
            Object.Destroy(foodImg);
            SpawnFood();
            GameHandler.AddScore();
            return true;
        }
        return false;
    }

    public bool ValidatePosition(Vector2Int position)
    {
        if(position.x < 1)
        {
            return true;
        }
        if (position.y < 1)
        {
            return true;
        }
        if (position.x > width-1)
        {
            return true;
        }
        if (position.y > height-1)
        {
            return true;
        }
        return false;
    }
}
