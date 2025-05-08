using System;
using UnityEngine;

public class EnemySpawnerCopntroller : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnInterval;
    private float spawnTimer;
    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            SpawnEnemy();
            spawnTimer = 0f;
        }

    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }
}
