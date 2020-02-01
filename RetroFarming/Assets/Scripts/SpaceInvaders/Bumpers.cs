using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumpers : MonoBehaviour
{
    //Bumpers
    private bool bumpersEnemyDetect = true;
    private bool bumpersEnemyBossDetect = true;

    //Bumpers collision
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") && bumpersEnemyDetect)
        {
            bumpersEnemyDetect = false;
            collision.GetComponentInParent<Wave>().waveWalkdown = true;
            StartCoroutine(WaitEnemyCollision());
        }
        if ((collision.CompareTag("EnemyBoss") || collision.CompareTag("EnemyMinion")) && bumpersEnemyBossDetect)
        {
            bumpersEnemyBossDetect = false;
            collision.GetComponentInParent<Wave>().WaveMooveReverse();
            StartCoroutine(WaitEnemyBossCollision());
        }
    }
    private IEnumerator WaitEnemyCollision()
    {
        yield return new WaitForSeconds(0.2f);
        bumpersEnemyDetect = true;
    }
    private IEnumerator WaitEnemyBossCollision()
    {
        yield return new WaitForSeconds(0.2f);
        bumpersEnemyBossDetect = true;
    }
}
