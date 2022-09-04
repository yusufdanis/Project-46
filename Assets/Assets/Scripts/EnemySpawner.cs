using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public EnemySpawner()
    {

    }

    public void spawnEnemies(EnemyType enemyType, EnemyTier enemyTier, int enemyCount = 3)
    {
        List<EnemyController> enemyList = Lists.EnemyLists.enemyDictionary[enemyType][enemyTier];

        List<EnemyController> randomEnemyList = enemyList.TakeRandom(enemyCount).ToList();

        List<Vector3> enemyLocations = generateEnemyLocations(enemyCount);

        foreach ((EnemyController enemy_, int i) in randomEnemyList.WithIndex())
        {
            Instantiate(enemy_.GetComponent<GameObject>(), enemyLocations[i], Quaternion.identity);
        }
        Debug.Log("spawning enemies");
    }

    public List<Vector3> generateEnemyLocations(int enemyCount)
    {
        Vector3 baseEnemyLocation = Constants.LocationConstants.enemyBaseLocation;
        List<Vector3> enemyLocationList = new List<Vector3>();

        enemyLocationList.Add(baseEnemyLocation);

        // Pattern: 10px up, 10px right for first 4 enemies
        // Pattern2: 10px up, 10px left for first 4 enemies

        // generate enemyCount number of locations
        for (int i = 0; i < enemyCount - 1; i++)
        {
            switch (i)
            {
                // if enemyCount is equal to 4 or less than 4
                case <3:
                    enemyLocationList.Add(enemyLocationList.Last() + Constants.LocationConstants.rightUpDistanceVector);
                    break;
                // if enemyCount is equal to 7 or in between 5-7
                case < 6:
                    enemyLocationList.Add(enemyLocationList.Last() + Constants.LocationConstants.leftUpDistanceVector);
                    break;
                default:
                    break;
            }
        }

        return enemyLocationList;
    }
}
