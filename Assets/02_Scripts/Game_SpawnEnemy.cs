using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_SpawnEnemy : MonoBehaviour
{
    public GameObject Enemy;

    public Transform[] spawnPoints;
    
    private int wave = 1;
    private int day;

    public GameObject[] enemies;

    public static Game_SpawnEnemy instance;

    private void Awake()
    {
        instance = this;
    }
    public void CreateEnemy()
    {
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        Instantiate(Enemy, spawnPoint.position, Quaternion.identity);
    }

    private void Update()
    {
    
    }
}
