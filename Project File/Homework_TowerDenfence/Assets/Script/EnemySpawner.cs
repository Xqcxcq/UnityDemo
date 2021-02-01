using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour {
    public static int EnemyAlive;
    public Wave[] waveEnemy;
//    public GameObject enemyPrefab;
    public Transform spawnPoint;        //生成位置
    public float spawnInterval = 1f;    //敌人生成的间隔时间
    private float countDown;
    private int waveIndex;
    void Start () {
        countDown = spawnInterval;
        EnemyAlive = 0;
    }
	void Update () {
        countDown -= Time.deltaTime;

        //如果存活数目>0就不让生成
        if (EnemyAlive > 0)
        {
            return;
        }

        if (waveIndex == waveEnemy.Length)
        {
            Debug.Log("Win");
            Application.LoadLevel("Win");
        }

        if (countDown <= 0)
        {
            countDown = spawnInterval;
            //倒计时结束，生成敌人
            SpawnEnemy();
        }
	}
    private void SpawnEnemy()
    {
        StartCoroutine(WaveEnemy());
    }

    IEnumerator WaveEnemy()
    {
        //检测放置数组越界
        if (waveIndex >= waveEnemy.Length)
        {
            yield break;
        }

        Wave wave = waveEnemy[waveIndex];

        EnemyAlive = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            Instantiate(wave.enemyPrefab, spawnPoint.position, spawnPoint.rotation);
            yield return new WaitForSeconds(1 / wave.rate);
        }
        waveIndex++;
    }
}
