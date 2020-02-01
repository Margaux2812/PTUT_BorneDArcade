using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    private float explosionDelay = 0.5f;

    private void Start()
    {
        Destroy(this.gameObject, explosionDelay);
    }
}
