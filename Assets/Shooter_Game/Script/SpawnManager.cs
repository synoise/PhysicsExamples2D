using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float interval = 5f;
    [SerializeField] GameObject enemyPrefab;

    [SerializeField] float maxSpawnRadius, minSpawnRadius;       // area where enemy can spawn outside radius

    private bool isGameStart = true;

    private void Start()
    {
        StartCoroutine(InstantiateEnemy());
    }

    private IEnumerator InstantiateEnemy()
    {
        while (isGameStart)
        {
            yield return new WaitForSeconds(interval);
            interval -= 0.0001f;

            Vector3 randomPos = RandomizePosition();
            Instantiate(enemyPrefab, randomPos, Quaternion.identity);
        }
    }

    private Vector3 RandomizePosition()
    {
        Vector3 randomPos;
        randomPos.y = enemyPrefab.transform.position.y;

        while (true)
        {
            randomPos.x = Random.Range(player.position.x - maxSpawnRadius, player.position.x + maxSpawnRadius);
            randomPos.z = Random.Range(player.position.z - maxSpawnRadius, player.position.z + maxSpawnRadius);

            if (Vector3.Distance(randomPos, player.position) > minSpawnRadius)
            {
                break;
            }
        }

        return randomPos;

    }
}
