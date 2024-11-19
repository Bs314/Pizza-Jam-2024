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
    [SerializeField] float bizonRatio = 1f;
    [SerializeField] float snakeRatio = 1f;
    //[SerializeField] float rockRatio = 1f;
    
    PlayerController playerController;
    
    

    void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        StartCoroutine(SpawnEnemy());   
         
    }

    
    void Update()
    {
                 
    }

    IEnumerator SpawnEnemy()
    {

        float randomFactor = UnityEngine.Random.Range(0f,1f);
        GameObject randEnemy;
        if (randomFactor <= bizonRatio)
        {
            randEnemy = enemies[0];
        }
        else if(randomFactor <= snakeRatio)
        {
            randEnemy = enemies[1];
        }
        else
        {
            randEnemy = enemies[2];
        }

        //Vector3 playerPosition = playerPrefab.transform.position;
        float randomX = UnityEngine.Random.Range(-spawnLimitX,spawnLimitX);
        float circleY = MathF.Sqrt((spawnLimitX*spawnLimitX)-(randomX*randomX));
        float randomMultiplier = UnityEngine.Random.Range(0, 2) == 0 ? -1 : 1;
        float randomY = circleY * randomMultiplier;
        Vector3 randomPosition = new Vector3(randomX+playerController.transform.position.x,randomY+playerController.transform.position.y,0);
        Instantiate(randEnemy, randomPosition, quaternion.identity);
        yield return new WaitForSeconds(spawnTime);
        StartCoroutine(SpawnEnemy());
    }


    public void SetBizonRatio(float ratio)
    {
        bizonRatio = ratio;
    }

    public void SetSnakeRatio(float ratio)
    {
        snakeRatio = ratio;   
    }

/*
    public void SetRockRatio(float ratio)
    {
        rockRatio = ratio;   
    }
*/
    public void SetSpawnTime(float timeSpawn)
    {
        spawnTime = timeSpawn;
    }


}
