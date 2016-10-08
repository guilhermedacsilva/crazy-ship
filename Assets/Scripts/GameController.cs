using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    
    public int levelNumber;
    private Levels levels;
    
	void Start ()
    {
        levels = new Levels(levelNumber);
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        GameObject enemyGameObject;
        LevelEnemy levelEnemy;
        int i;
        while (true)
        {
            // iterate the enemies types of the level
            while (levels.HasMoreEnemyTypes())
            {
                levelEnemy = levels.GetCurrentLevelEnemy();
                enemyGameObject = Resources.Load<GameObject>(levelEnemy.PrefabPath);
                for (i = 0; i < levelEnemy.Quantity; i++)
                {
                    Instantiate(enemyGameObject, new Vector3(0, 0, 30), Quaternion.Euler(0, 0, Random.Range(0, 359)));
                    yield return new WaitForSeconds(Random.Range(levelEnemy.SpawnTimeMin, levelEnemy.SpawnTimeMax));
                }

                levels.ChangeToNextEnemyType();
            }

            levels.IncreaseLevel();

            if (levels.IsFinishedGame())
            {
                break;
            }
            
        }
    }
}
