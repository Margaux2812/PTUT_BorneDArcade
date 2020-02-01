using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    //Enemy bullet
    private float enemyBulletForce = 400f, enemyBulletDestroyTime = 1f;
    private Rigidbody2D enemyBulletRb;

    private void Awake()
    {
        enemyBulletRb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        enemyBulletRb.AddForce(Vector2.down * enemyBulletForce);
        Destroy(gameObject, enemyBulletDestroyTime);
    }
}
