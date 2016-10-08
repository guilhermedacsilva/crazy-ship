using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Level
{
    private List<LevelEnemy> enemyList;

    public Level()
    {
        enemyList = new List<LevelEnemy>(15);
    }

    public void AddEnemy(LevelEnemy e)
    {
        enemyList.Add(e);
    }

    public List<LevelEnemy> EnemyList
    {
        get
        {
            return enemyList;
        }
    }
}

public class Levels
{
    private List<Level> levels;
    private int levelNumber;
    private Level currentLevel;
    private int currentEnemyIndex = 0;

    public Levels(int number)
    {
        levelNumber = number;
        levels = new List<Level>(1);
        Level l;

        l = new Level();
        l.AddEnemy(new LevelEnemy("Prefabs/Enemy Parent", 15, 1, 2));
        levels.Add(l);

        currentLevel = levels[levelNumber];
    }

    public bool HasMoreEnemyTypes()
    {
        return currentEnemyIndex < currentLevel.EnemyList.Count;
    }

    public LevelEnemy GetCurrentLevelEnemy()
    {
        return currentLevel.EnemyList[currentEnemyIndex];
    }

    public void ChangeToNextEnemyType()
    {
        currentEnemyIndex++;
    }

    public void IncreaseLevel()
    {
        
        currentEnemyIndex = 0;
        levelNumber++;
        currentLevel = IsFinishedGame() ? null : levels[levelNumber];
    }

    public bool IsFinishedGame()
    {
        return levelNumber >= levels.Count;
    }
}
