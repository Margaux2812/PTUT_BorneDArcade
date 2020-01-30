using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class easter_egg : MonoBehaviour
{
    private static easter_egg instance;

    private void Awake()
    {
        instance = this;
    }

    public static void changeAssetsToEaster(SnakeMovement snake)
    {
       // snakeBody.GetComponent<Animator>().runtimeAnimatorController = chicken.poussin as RuntimeAnimatorController;
    }
}
