using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : EnemyController
{
    //Lives
    private int bossLives = 9;

    //Sound
    [SerializeField] private AudioClip[] audioClip;
    private AudioSource audiosource;

    public int BossLives
    {
        get
        {
            return bossLives;
        }
    }

    private void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        wave = GameObject.Find("Wave").GetComponent<Wave>();
    }

    //Boss loose a live (touch)
    public void BossLoseLive()
    {
        bossLives -= 1;
        audiosource.PlayOneShot(audioClip[0]);
        BossStages();
    }

    //Changes if boss change stage
    private void BossStages()
    {
        if (bossLives == 6)
        {
            audiosource.PlayOneShot(audioClip[1]);
            GetComponent<Animator>().SetTrigger("boss2A");
            enemyNbBullets = 2;
            wave.waveSpeed /= 1.2f;
        }
        else if (bossLives == 3)
        {
            audiosource.PlayOneShot(audioClip[1]);
            GetComponent<Animator>().SetTrigger("boss3A");
            enemyNbBullets = 3;
            wave.waveSpeed /= 1.2f;
            wave.WaveGeneratorMinions();
        }
    }

    private void AnimateEnemy()
    {
    }

}
