using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // The enemy prefab
    public int enemyCount = 10; // Number of enemies to spawn
    public Vector3 spawnAreaSize = new Vector3(10, 0, 10); // The size of the area within which enemies will be spawned
    public gamemanager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            gamemanager.enemyCount++;
        }
    }

    void SpawnEnemy()
    {
        // Generate a random position within the spawn area
        Vector3 spawnPosition = new Vector3(
            Random.Range(-spawnAreaSize.x / 2, spawnAreaSize.x / 2),
            spawnAreaSize.y,
            Random.Range(-spawnAreaSize.z / 2, spawnAreaSize.z / 2)
        );

        // Add the spawn area's position to the spawn position to move it into the correct place in the world
        spawnPosition += transform.position;

        // Instantiate the enemy at the random position
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
