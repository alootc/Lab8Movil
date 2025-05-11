using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawn = 2f;
    public GameObject enemyPrefab;
    public float spawnRange = 5f;

    void Start()
    {
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        float randomY = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPosition = new Vector3(transform.position.x, transform.position.y + randomY, transform.position.z);
        
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        
        Invoke("SpawnEnemy", spawn);
    }
}