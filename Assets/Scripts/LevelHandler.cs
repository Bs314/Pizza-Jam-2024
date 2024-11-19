using System;
using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] float levelThreshold = 20f;
    
    float clock;
    public int level = 1;

    float bizonRatio = 1f;
    float snakeRatio = 1f;
    float spawnTime = 5;
    
    //bool isEnemySpawnerUpdated = false;
    void Start()
    {
        
    }

    
    void Update()
    {
        LevelUpdater();
        

    }

    private void LevelUpdater()
    {
        clock += Time.deltaTime;
        if (clock >= levelThreshold)
        {
            clock = 0;
            level += 1;
            EnemySpawnerUpdater(level);
        }
    }

    private void EnemySpawnerUpdater(int level)
    {

        if(level%2==0 && bizonRatio>0)
        {
            bizonRatio -= 0.1f;
            enemySpawner.SetBizonRatio(bizonRatio);
        }

        if(level>7 && level%3==2 && snakeRatio>0)
        {
            snakeRatio -= 0.1f;
            enemySpawner.SetSnakeRatio(snakeRatio);
        }
        if(level>2 && level%2==1 && spawnTime>=1)
        {
            spawnTime -= 0.3f;
            enemySpawner.SetSpawnTime(spawnTime);
        }
    }
}
