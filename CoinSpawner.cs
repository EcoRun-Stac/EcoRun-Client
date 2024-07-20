using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab; // ������ ���� ������
    public float spawnInterval = 2f; // ���� ���� ����
    public float destroyX = -10f; // ������ ������� X ��ġ
    public float newX = -7f;

    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnCoin();
            nextSpawnTime = Time.time + spawnInterval;
        }
    }

    void SpawnCoin()
    {
        newX += 2;
        Vector2 spawnPosition = new Vector2(newX, -1f);
        GameObject coin = Instantiate(coinPrefab, spawnPosition, Quaternion.identity); // ���� ����
    }
}


