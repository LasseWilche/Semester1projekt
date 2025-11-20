using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public static int activeEnemies = 0;

    public GameObject SpawnEnemy(GameObject enemyPrefab)
    {
        GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        activeEnemies++;

        return enemy;
    }
}
