using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemiesToSpawn = 10;
    public Vector2 spawnAreaSize = new Vector2(10f, 10f);

    // Start is called before the first frame update
    void Start()
    {

        SpawnEnemies();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < numberOfEnemiesToSpawn; i++)
        {
            // Generate random position within the spawn area
            Vector2 randomPosition = transform.position + new Vector3(Random.Range(-spawnAreaSize.x / 2f, spawnAreaSize.x / 2f),
                                                                      Random.Range(-spawnAreaSize.y / 2f, spawnAreaSize.y / 2f), 0f);

            // Spawn enemy at the random position
            GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }

    }
}
