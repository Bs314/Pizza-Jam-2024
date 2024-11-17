using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemySpawner : MonoBehaviour
{
    
    [SerializeField] List<GameObject> enemies;
    [SerializeField] float spawnLimitX = 30f;
    [SerializeField] float spawnTime = 5;

    

    void Start()
    {
        
        StartCoroutine(SpawnEnemy());   
    }

    
    void Update()
    {
                 
    }

    IEnumerator SpawnEnemy()
    {
        //Vector3 playerPosition = playerPrefab.transform.position;
        float randomX = UnityEngine.Random.Range(-spawnLimitX,spawnLimitX);
        float circleY = MathF.Sqrt((spawnLimitX*spawnLimitX)-(randomX*randomX));
        float randomMultiplier = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        float randomY = circleY * randomMultiplier;
        Vector3 randomPosition = new Vector3(randomX,randomY,0);
        Debug.Log(randomPosition);
        Instantiate(enemies[0], randomPosition, quaternion.identity);
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(SpawnEnemy());
    }


}
