using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //Scripts
    protected Wave wave;

    //Shoot
    [SerializeField] public GameObject enemyBullet;
    public int enemyNbBullets;
    public float enemyShootRate = 0.999f;
    private bool enemyCanShoot = true;

    //Animation
    Sprite spriteEnemy1;
    [SerializeField] public Sprite spriteEnemy2;
    [SerializeField] public Sprite spriteEnemy3;
    [SerializeField] public Sprite spriteEnemy4;

    private void Awake()
    {
        spriteEnemy1 = GetComponent<SpriteRenderer>().sprite;
        wave = GameObject.Find("Wave").GetComponent<Wave>();
    }

    //Loop
    private void Update()
    {
        EnemyShoot();
    }

    //Enemy shoot
    private void EnemyShoot()
    {
        if (enemyCanShoot && Random.value > enemyShootRate)
        {
            StartCoroutine(EnemyShootIterator());
            StartCoroutine(EnemyShootPause());
        }
    }
    private IEnumerator EnemyShootPause()
    {
        enemyCanShoot = false;
        yield return new WaitForSeconds(0.3f);
        if (wave.waveCanMoove == true)
        {
            enemyCanShoot = true;
        }
    }
    private IEnumerator EnemyShootIterator()
    {
        Vector3 enemyShootPosition = transform.position;
        for (int j = 0; j < enemyNbBullets; j++)
        {
            Instantiate(enemyBullet, enemyShootPosition, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }

    //Enemy change if shoot
    private void EnemyShootStop()
    {
        enemyCanShoot = false;
    }
    private void EnemyShootGo()
    {
        enemyCanShoot = true;
    }

    //Animation enemy
    private void AnimateEnemy()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Sprite nextSprite;
        if (wave.waveWalkright)
        {
            nextSprite = sr.sprite == spriteEnemy1 ? spriteEnemy2 : spriteEnemy1;
        }
        else
        {
            nextSprite = sr.sprite == spriteEnemy3 ? spriteEnemy4 : spriteEnemy3;
        }
        sr.sprite = nextSprite;
    }
}
