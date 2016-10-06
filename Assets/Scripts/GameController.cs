using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public GameObject enemy;
    
	void Start () {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        StartCoroutine(SpawnEnemies());
	}

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            Instantiate(enemy, new Vector3(0, 0, 30), Quaternion.Euler(0, 0, Random.Range(0, 359)));

            yield return new WaitForSeconds(2);
        }
    }
}
