using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    //Scripts
    private Game game;
    private PlayerController playercontroller;
    private Wave wave;

    //Bullet
    private float force = 600f, destroyTime = 1f;
    private Rigidbody2D playerBulletRb;

    //Animation
    [SerializeField] private GameObject enemyExplosionPrefab = null;
    [SerializeField] private GameObject bossExplosionPrefab = null;

    private void Awake()
    {
        playerBulletRb = GetComponent<Rigidbody2D>();
        playercontroller = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        game = GameObject.Find("EventSystem").GetComponent<Game>();
        wave = GameObject.Find("Wave").GetComponent<Wave>();
    }

    private void Start()
    {
        playerBulletRb.AddForce(Vector2.up * force);
        Destroy(gameObject, destroyTime);
    }

    //Destroy
    private void OnDestroy()
    {
        playercontroller.playerCanShoot = true;
    }

    //Bullet enemy collision : enemy and bullet enemy
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletEnemy"))
        {
            Destroy(collision.gameObject);
            Instantiate(enemyExplosionPrefab, collision.transform.position, Quaternion.identity);
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            game.ScoreGame += 10;
        }
        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyMinion"))
        {
            Destroy(collision.gameObject);
            Destroy(this.gameObject);
            Instantiate(enemyExplosionPrefab, collision.transform.position, Quaternion.identity);
            wave.remainingEnemies -= 1;
            wave.isWaveEmpty();
            game.ScoreGame += 50;
        }
        if (collision.gameObject.CompareTag("EnemyBoss"))
        {
            Destroy(this.gameObject);
            collision.GetComponent<BossController>().BossLoseLive();
            if (collision.GetComponent<BossController>().BossLives == 0)
            {
                Destroy(collision.gameObject);
                foreach (Transform child in wave.transform)
                {
                    Destroy(child.gameObject);
                }
                Instantiate(bossExplosionPrefab, collision.transform.position, Quaternion.identity);
                wave.remainingEnemies -= 1;
                wave.isWaveEmpty();
                game.ScoreGame += 100;
            }
        }
    }
}
