using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesSlots : MonoBehaviour
{
    //LivesSlots
    [SerializeField] private GameObject[] livesSlots;

    private void Awake()
    {
        livesSlots = GameObject.FindGameObjectsWithTag("Slot");
    }

    //Lose a live slot
    public void LoseLivesSlot(int lives)
    {
        switch (lives)
        {
            case 2:
                livesSlots[0].SetActive(false);
                break;
            case 1:
                livesSlots[1].SetActive(false);
                break;
            case 0:
                livesSlots[2].SetActive(false);
                break;
        }
    }
}
