using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;

    public Transform[] spawnPoints;

    public static Game_SpawnEnemy instance;

    private void Awake()
    {
        instance = this;
    }
    public void CreateEnemy()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(enemyPrefab,spawnPoint.position,spawnPoint.rotation);
    }
}
