using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey;
using CodeMonkey.Utils;
using System;

public class SnakeMovement : MonoBehaviour
{
    private enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }

    private enum State
    {
        Alive,
        Dead
    }

    private Direction gridMoveDirection;
    private Vector2Int gridPosition;
    private float gridMoveTimer;
    private float gridMoveTimerMax;
    private LevelGrid levelGrid;
    private int snakeBodySize;
    private List<SnakeMovePosition> snakeMovePositionList;
    private List<SnakeBodyPart> snakeBodyParts;
    private State state;
    public Animator snakeBody;
    public float timer;

    bool canMove = true;
    float coolDown;

    public RuntimeAnimatorController poussin;

    public void Setup(LevelGrid levelGrid)
    {
        this.levelGrid = levelGrid;
    }

    private void Awake()
    {
        gridPosition = new Vector2Int(10, 10);
        gridMoveTimerMax = .2f;
        coolDown = gridMoveTimerMax;
        gridMoveTimer = gridMoveTimerMax;
        gridMoveDirection = Direction.Right;

        snakeMovePositionList = new List<SnakeMovePosition>();
        snakeBodyParts = new List<SnakeBodyPart>();
        snakeBodySize = 0;
        snakeBody = GetComponent<Animator>();
        snakeBody.SetFloat("Horizontal", 1);
        snakeBody.SetFloat("Vertical", 0);

        state = State.Alive;

        if (GameHandler.isSpecialMode())
        {
            easter_egg.changeAssetsToEaster(this);
        }
    }

    private void Update()
    {
        switch (state)
        {
            case State.Alive:
                HandleEvent();
                HandleGridMovement();
                break;
            case State.Dead:
                break;
        }
        timer += Time.deltaTime;
        GameHandler.SetTime(timer);
    }

    private void HandleEvent()
    {
        if (canMove)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (gridMoveDirection != Direction.Down)
                {
                    canMove = false;
                    Invoke("CooledDown", coolDown);
                    gridMoveDirection = Direction.Up;
                    changeAsset(Direction.Up);
                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (gridMoveDirection != Direction.Up)
                {
                    canMove = false;
                    Invoke("CooledDown", coolDown);
                    gridMoveDirection = Direction.Down;
                    changeAsset(Direction.Down);
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (gridMoveDirection != Direction.Right)
                {
                    canMove = false;
                    Invoke("CooledDown", coolDown);
                    gridMoveDirection = Direction.Left;
                    changeAsset(Direction.Left);
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (gridMoveDirection != Direction.Left)
                {
                    canMove = false;
                    Invoke("CooledDown", coolDown);
                    gridMoveDirection = Direction.Right;
                    changeAsset(Direction.Right);
                }
            }
        }
    }

    private void CooledDown()
    {
        canMove = true;
    }

    private void changeAsset(Direction direction)
    {
        //Play sound
        SoundsManager.PlaySound(SoundsManager.Sound.Moves);

        switch (direction)
        {
            default:
            case Direction.Up:
                snakeBody.SetFloat("Horizontal", 0);
                snakeBody.SetFloat("Vertical", 1);
                break;
            case Direction.Down: //Down
                snakeBody.SetFloat("Horizontal", 0);
                snakeBody.SetFloat("Vertical", -1);
                break;
            case Direction.Right: //Right
                snakeBody.SetFloat("Horizontal", 1);
                snakeBody.SetFloat("Vertical", 0);
                break;
            case Direction.Left: //Left
                snakeBody.SetFloat("Horizontal", -1);
                snakeBody.SetFloat("Vertical", 0);
                break;
        }
    }

    private void HandleGridMovement()
    {

        //Vitesse change
        if (snakeBodySize == 10)
        {
            coolDown = gridMoveTimerMax;
            gridMoveTimerMax = .15f;
        }
        if (snakeBodySize == 20)
        {
            coolDown = gridMoveTimerMax;
            gridMoveTimerMax = .1f;
        }
        if (snakeBodySize == 30)
        {
            coolDown = gridMoveTimerMax;
            gridMoveTimerMax = .06f;
        }


        gridMoveTimer += Time.deltaTime;
        if (gridMoveTimer >= gridMoveTimerMax)
        {
            gridMoveTimer -= gridMoveTimerMax;

            SnakeMovePosition snakeMovePosition = new SnakeMovePosition(gridPosition, gridMoveDirection);
            snakeMovePositionList.Insert(0, snakeMovePosition);

            Vector2Int gridMovePositionVector;
            switch(gridMoveDirection){
                default:
                case Direction.Right : gridMovePositionVector = new Vector2Int(2, 0); break;
                case Direction.Left  : gridMovePositionVector = new Vector2Int(-2, 0); break;
                case Direction.Up    : gridMovePositionVector = new Vector2Int(0, 2); break;
                case Direction.Down  : gridMovePositionVector = new Vector2Int(0, -2); break;
            }

            gridPosition += gridMovePositionVector;

            bool isDead = levelGrid.ValidatePosition(gridPosition);

            //Mort par touche de l'écran
            if (isDead)
            {
                state = State.Dead;
                GameHandler.SnakeDied();
            }

            bool snakeAte = levelGrid.TryEatFood(gridPosition);

            if (snakeAte)
            {
                //Play sound
                SoundsManager.PlaySound(SoundsManager.Sound.gotEgg);

                snakeBodySize++;
                CreateSnakeBody();
            }

            if (snakeMovePositionList.Count >= snakeBodySize + 1)
            {
                snakeMovePositionList.RemoveAt(snakeMovePositionList.Count - 1);
            }

            UpdateSnakeBodyParts();

            //Mort par toucher la queue
            foreach (SnakeBodyPart snakeBodyPart in snakeBodyParts)
            {
                Vector2Int snakeBodyPartPosition = snakeBodyPart.GetPosition();
                if(gridPosition == snakeBodyPartPosition)
                {
                    state = State.Dead;
                    GameHandler.SnakeDied();
                }
            }

            transform.position = new Vector3(gridPosition.x, gridPosition.y, 0);
        }
    }

    public List<Vector2Int> GetListSnakePosition()
    {
        List<Vector2Int> gridPositionsList = new List<Vector2Int> { gridPosition };
        foreach(SnakeMovePosition snakeMovePosition in snakeMovePositionList)
        {
            gridPositionsList.Add(snakeMovePosition.GetGridPosition());
        }
        return gridPositionsList;
    }

    private void CreateSnakeBody()
    {
        snakeBodyParts.Add(new SnakeBodyPart(snakeBodyParts.Count, this));
    }

    private void UpdateSnakeBodyParts()
    {
        for (int i = 0; i < snakeBodyParts.Count; i++)
        {
            snakeBodyParts[i].SetSnakeMovePosition(snakeMovePositionList[i]);
        }
    }

    private class SnakeBodyPart
    {
        private SnakeMovePosition gridPosition;
        private Transform transform;
        private GameObject snakeBody;

        public SnakeBodyPart(int index, SnakeMovement chicken)
        {
            snakeBody = new GameObject("Poussin", typeof(SpriteRenderer));
            snakeBody.AddComponent<Animator>();
            snakeBody.GetComponent<Animator>().runtimeAnimatorController = chicken.poussin as RuntimeAnimatorController;
            snakeBody.GetComponent<Animator>().updateMode = AnimatorUpdateMode.AnimatePhysics; 
            snakeBody.GetComponent<Animator>().SetFloat("Horizontal", 1);
            snakeBody.GetComponent<Animator>().SetFloat("Vertical", 0);
            transform = snakeBody.transform;
        }

        public void SetSnakeMovePosition(SnakeMovePosition position)
        {
            this.gridPosition = position;
            transform.position = new Vector3(position.GetGridPosition().x, position.GetGridPosition().y, 0);
            changeAssetAnimator(gridPosition.GetDirection());
        }

        public Vector2Int GetPosition()
        {
            return gridPosition.GetGridPosition();
        }

        public void changeAssetAnimator(Direction direction)
        {
            switch (direction)
            {
                default:
                case Direction.Up:
                    snakeBody.GetComponent<Animator>().SetFloat("Horizontal", 0);
                    snakeBody.GetComponent<Animator>().SetFloat("Vertical", 1);
                    break;
                case Direction.Down: //Down
                    snakeBody.GetComponent<Animator>().SetFloat("Horizontal", 0);
                    snakeBody.GetComponent<Animator>().SetFloat("Vertical", -1);
                    break;
                case Direction.Right: //Right
                    snakeBody.GetComponent<Animator>().SetFloat("Horizontal", 1);
                    snakeBody.GetComponent<Animator>().SetFloat("Vertical", 0);
                    break;
                case Direction.Left: //Left
                    snakeBody.GetComponent<Animator>().SetFloat("Horizontal", -1);
                    snakeBody.GetComponent<Animator>().SetFloat("Vertical", 0);
                    break;
            }
        }
    }


    private class SnakeMovePosition
    {
        private Vector2Int gridPosition;
        private Direction direction;

        public SnakeMovePosition(Vector2Int gridPosition, Direction direction)
        {
            this.gridPosition = gridPosition;
            this.direction = direction;
        }

        public Vector2Int GetGridPosition()
        {
            return gridPosition;
        }

        public Direction GetDirection()
        {
            return direction;
        }
    }
}
