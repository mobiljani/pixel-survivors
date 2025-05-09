using System;
using System.Collections.Generic;
using UnityEngine;




public class EnemySpawnController : MonoBehaviour
{
    [Serializable]
    public class Wave
    {
        public GameObject enemyPrefab;
        public int noOfEnemyToSpawn = 2;
        public int currentCount;
        public float spawnTimer;
        public float spawnInterval = 2f;

    }

    public List<Wave> waves;
    private int waveIndex = 0;

    void Update()
    {
        var w = waves[waveIndex];
        w.spawnTimer += Time.deltaTime;
        if (w.spawnTimer >= w.spawnInterval)
        {
            SpawnEnemy();
            w.currentCount++;
            w.spawnTimer = 0;
        }

        if (w.currentCount == w.noOfEnemyToSpawn)
        {
            waveIndex++;
            w.currentCount = 0;
        }

        if (waves.Count == waveIndex)
        {
            waveIndex = 0;
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(waves[waveIndex].enemyPrefab, transform.position, transform.rotation);
    }
}
