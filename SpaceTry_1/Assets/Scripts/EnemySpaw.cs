using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpaw : MonoBehaviour
{
    public GameObject EnemySpawner;

    float maxSpawnRateInSeconds = 2f;

    void Start()
    {

    }


    void Update()
    {
        
    }

    void SpawnEnemy()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint (new Vector2(0,0));

        Vector2 max = Camera.main.ViewportToWorldPoint (new Vector2(1,1));

        GameObject anEnemy = (GameObject)Instantiate(EnemySpawner);
        anEnemy.transform.position = new Vector2 (Random.Range (min.x, max.x), max.y);

        ScheduleNextEnemySpawn();

    }

    void ScheduleNextEnemySpawn()
    {
        float spawnInNSeconds;
        if(maxSpawnRateInSeconds > 1f)
        {
            spawnInNSeconds = Random.Range(1f, maxSpawnRateInSeconds);
        }
        else
        {
            spawnInNSeconds = 1f;
        }

        Invoke ("SpawnEnemy", maxSpawnRateInSeconds);
    }

    void IncreaseSpawnRate()
    {
        if(maxSpawnRateInSeconds > 0.25f)
        {
            maxSpawnRateInSeconds -= 0.04f;
        }
        if(maxSpawnRateInSeconds == 0.25f)
        {
            CancelInvoke("IncreaseSpawnRate");
        }
    }

    public void ScheduleEnemySpawner()
    {
        Invoke ("SpawnEnemy", maxSpawnRateInSeconds);

        InvokeRepeating("IncreaseSpawnRate", 0f, 1f);
    }

    public void UnscheduleEnemySpawner()
    {
        CancelInvoke("SpawnEnemy");
        CancelInvoke("IncreaseSpawnRate");
    }

}
