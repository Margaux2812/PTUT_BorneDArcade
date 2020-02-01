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

        SpawnFood(false);
    }

    private void SpawnFood(bool specialMode)
    {
        do
        {
            foodPosition = new Vector2Int(2*Random.Range(1, width/2), 2*Random.Range(1, height/2));
        } while (snake.GetListSnakePosition().IndexOf(foodPosition) != -1);

        foodImg = new GameObject("Food", typeof(SpriteRenderer));
        if (specialMode)
        {
            foodImg.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.snakeFoodSpriteSpecial;
        }
        else
        {
            foodImg.GetComponent<SpriteRenderer>().sprite = GameAssets.instance.snakeFoodSprite;
        }
        foodImg.transform.position = new Vector3(foodPosition.x, foodPosition.y, 0);
    }

    public void changeFood()
    {
        Object.Destroy(foodImg);
        SpawnFood(true);
    }

    public bool TryEatFood(Vector2Int snakePosition, bool specialMode)
    {
        if(snakePosition == foodPosition)
        {
            Object.Destroy(foodImg);
            SpawnFood(specialMode);
            GameHandler.AddScore();
            return true;
        }
        return false;
    }

    public bool goEasterEgg(int y, SnakeMovement snake)
    {
        if (Input.GetButton("Fire1") && y==18 && !snake.inSpecialMode)
        {
            snake.resetIntoEasterEgg();
            return false;
        }
        return true;
    }

    public bool ValidatePosition(Vector2Int position, SnakeMovement snake)
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
            return goEasterEgg(position.y, snake);
        }
        if (position.y > height-1)
        {
            return true;
        }
        return false;
    }
}
