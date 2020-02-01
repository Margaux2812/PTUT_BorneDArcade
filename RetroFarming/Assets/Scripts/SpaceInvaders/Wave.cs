using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
	//Scripts
	private Game game;

	//Wave movements
	private Vector2 positionInitialWave;
	public bool waveWalkright = true, waveWalkdown = false;
	private float waveStepRight = 0.5f, waveStepDown = 0.5f, waveSpeedEnemies = 0.8f, waveSpeedBoss = 0.3f;
	public float waveSpeed;
	public bool waveCanMoove = true;

	//Wave enemies
	[SerializeField] public GameObject[] enemyType;
	private float spaceColumns = 1f, spaceRows = 1.4f;
	private int nbEnemiesLine = 4;
	private int totalEnemies;
	public int remainingEnemies;

	//Sound
	[SerializeField] private AudioClip[] audioClip = null;
	private AudioSource audiosource;

	private void Awake()
	{
		game = GameObject.Find("EventSystem").GetComponent<Game>();
		audiosource = GetComponent<AudioSource>();
		positionInitialWave = transform.position;
		WaveGenerator(0, 0);
	}

	private void Start()
	{
		StartCoroutine(WaveMoove());
	}

	//Wave moove
	private IEnumerator WaveMoove()
	{
		while (waveCanMoove)
		{
			if (waveWalkdown)
			{
				WaveMooveReverse();
				transform.Translate(Vector2.down * waveStepDown);
				waveWalkdown = false;
			}
			else
			{
				Vector2 direction = waveWalkright ? Vector2.right : Vector2.left;
				transform.Translate(direction * waveStepRight);
			}
			BroadcastMessage("AnimateEnemy");
			WavePlaySound();
			yield return new WaitForSeconds(waveSpeed);
		}
	}

	//Wave play sound
	private void WavePlaySound()
	{
		int currentClip = 0;
		currentClip = currentClip < audioClip.Length - 1 ? currentClip += 1 : currentClip = 0;
		audiosource.PlayOneShot(audioClip[currentClip]);
	}

	//Test if wave empty
	public void isWaveEmpty()
	{
		if (remainingEnemies == 0)
		{
			StopWave();
			game.Win();
		}
	}

	//Wave stop
	public void StopWave()
	{
		//StopAllCoroutines();
		waveCanMoove = false;
		if(remainingEnemies > 0)
		{
			BroadcastMessage("EnemyShootStop");
		}
	}

	//Wave restart
	public void RestartWave()
	{
		transform.position = positionInitialWave;
		waveCanMoove = true;
		waveWalkright = true;
		waveWalkdown = false;
		if (remainingEnemies > 0)
		{
			BroadcastMessage("EnemyShootGo");
		}
		StartCoroutine(WaveMoove());
	}

	//Wave generator
	public void WaveGenerator(int nbEnemiesType, int level)
	{
		if(nbEnemiesType == 3)
		{
			if(level != 3)
			{
				waveSpeedBoss /= 1.2f;
			}
			if (waveSpeedBoss < 0.1f)
			{
				waveSpeedEnemies = 0.1f;
			}
			waveSpeed = waveSpeedBoss;
			GameObject enemy = Instantiate(enemyType[3].gameObject, new Vector2(transform.position.x + 0.4f, transform.position.y), Quaternion.identity);
			enemy.transform.SetParent(this.transform);
			enemy.name = "Boss";
		} else
		{
			if (nbEnemiesType == 0 && level != 0)
			{
				waveSpeedEnemies /= 1.2f;
				if(nbEnemiesLine < 10)
				{
					nbEnemiesLine += 1;
				}
				if (waveSpeedEnemies < 0.2f)
				{
					waveSpeedEnemies = 0.2f;
				}
			}
			waveSpeed = waveSpeedEnemies;
			for (int i = 0; i <= nbEnemiesType; i++)
			{
				float posY = transform.position.y - (spaceRows * ((nbEnemiesType) - i));
				for (int j = 0; j < nbEnemiesLine; j++)
				{
					Vector2 pos = new Vector2(transform.position.x + (spaceColumns * j), posY);
					GameObject enemy = Instantiate(enemyType[i].gameObject, pos, Quaternion.identity);
					enemy.transform.SetParent(this.transform);
					enemy.name = "Enemy" + (j + 1) + "-row:" + (i + 1);
				}
			}
		}
		totalEnemies = transform.childCount;
		remainingEnemies = totalEnemies;
	}

	public void WaveGeneratorMinions()
	{
		float posY = transform.position.y - (spaceRows * 2);
		for (int j = 0; j < nbEnemiesLine; j++)
		{
			Vector2 pos = new Vector2(transform.position.x + (spaceColumns * j), posY);
			GameObject enemy = Instantiate(enemyType[4].gameObject, pos, Quaternion.identity);
			enemy.transform.SetParent(this.transform);
			enemy.name = "EnemyMinion" + (j + 1) + "-row:" + (1);
		}
		totalEnemies = transform.childCount;
		remainingEnemies = totalEnemies;
	}

	public void WaveMooveReverse()
	{
		waveWalkright = !waveWalkright;
	}
}
