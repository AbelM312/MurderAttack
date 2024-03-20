using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int numberOfEnemiesToSpawn = 10;
    //public Vector2 spawnAreaSize = new Vector2(10f, 10f);
    public Transform spawn;

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
            Vector2 randomPosition = transform.position + new Vector3(Random.Range(spawn.position.x - 5f, spawn.position.x + 5f), 0f, 0f);

            // Spawn enemy at the random position
            GameObject enemy = Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
        }

    }
}
