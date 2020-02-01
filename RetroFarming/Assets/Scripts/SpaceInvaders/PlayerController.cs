using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Scripts
    private Game game;

    //Player movements
    private Vector2 playerPosition;
    private float playerSpeed = 8f;
    private float playerLimitX = 5.6f;
    private bool playerDetectCollision = true;
    private bool playerCanMove = true;

    //Player shoot
    [SerializeField] private GameObject playerBullet = null;
    private Transform ejectPosition;
    public bool playerCanShoot = true;

    private void Awake()
    {
        game = GameObject.Find("EventSystem").GetComponent<Game>();
        playerPosition = transform.position;
        ejectPosition = transform.Find("Eject");
    }

    //Loop
    private void Update()
    {
        PlayerMove();
        PlayerShoot();
    }

    //Player move
    private void PlayerMove()
    {
        if (playerCanMove)
        {
            playerPosition.x += Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
            playerPosition.x = Mathf.Clamp(playerPosition.x, -playerLimitX, playerLimitX);
            transform.position = playerPosition;
        }
    }

    //Player shoot
    private void PlayerShoot()
    {
        if (Input.GetButtonDown("Fire1") && playerCanShoot)
        {
            playerCanShoot = false;
            Instantiate(playerBullet, ejectPosition.position, Quaternion.identity);
        }
    }

    //Player collision (enemy or bullet enemy)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && playerDetectCollision || collision.CompareTag("BulletEnemy"))
        {
            playerDetectCollision = false;
            StartCoroutine(PlayerKill());
        }
    }
    private IEnumerator PlayerKill()
    {
        game.Lose();
        PlayerExplosion();
        GetComponent<BoxCollider2D>().enabled = false;
        playerCanShoot = false;
        playerCanMove = false;
        yield return new WaitForSeconds(0.2f);
        playerDetectCollision = true;
    }

    //Player animation explosion
    private void PlayerExplosion()
    {
        GetComponent<Animator>().SetTrigger("playerExplosionA");
        GetComponent<AudioSource>().Play();
    }

    //Player initialise
    public void PlayerInitialise()
    {
        GetComponent<Animator>().SetTrigger("playerNormalA");
        GetComponent<BoxCollider2D>().enabled = true;
        playerCanShoot = true;
        playerCanMove = true;
    }
}