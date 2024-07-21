using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // ������ ���� ������
    public GameObject enemyPrefab; // ������ �� ������
    public float spawnInterval = 4f; // ���� ���� ����
    public float destroyX = -10f; // ������ ������� X ��ġ
    public float newX = -7f;
    public float newY = 0f;
    public float spawnItem = 0f;

    private float nextSpawnTime = 0f;

    void Update()
    {
        spawnItem = Random.Range(0, 2);
        Debug.Log(spawnItem);
        if (Time.time > nextSpawnTime)
        {
            if(spawnItem == 0)
            {
                SpawnCoin();
            }
            else
            {
                SpawnEnemy();
            }
        }
    }

    void SpawnCoin()
    {
        newY = Random.Range(-1f, 1f);
        newX += 1;
        Vector2 spawnPosition = new Vector2(newX, newY);
        GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity); // ���� ����
    }

    void SpawnEnemy()
    {
        newY = Random.Range(-1f, 1f);
        newX += 1;
        Vector2 spawnPosition = new Vector2(newX, newY);
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // ���� ����
    }
}


