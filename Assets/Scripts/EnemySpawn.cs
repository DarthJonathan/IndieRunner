using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	public List<GameObject> enemyPrefabs = new List<GameObject>(0);
	public static float increaseDifficulty = 1;
	private int enemyCount = 0;
	GameObject newEnemies;
	Transform cars;

	void Start ()
	{
        
        //			New Objects for enemy
        newEnemies = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)]);
    
            //			Activate the enemy
            newEnemies.SetActive(true);

            enemyCount = newEnemies.gameObject.transform.childCount;
            cars = newEnemies.gameObject.transform.GetChild(enemyCount - 1);
        
        //else
        //{
        //    //			New Objects for enemy
        //    newEnemies = Instantiate(enemyPrefabs2[Random.Range(0, enemyPrefabs.Count)]);

        //    //			Activate the enemy
        //    newEnemies.SetActive(true);

        //    enemyCount = newEnemies.gameObject.transform.childCount;
        //    cars = newEnemies.gameObject.transform.GetChild(enemyCount - 1);
        //}
	}
	
    
	// Update is called once per frame
	void Update ()
    {

		if (cars.position.x < -5)
		{
			newEnemies = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)]);
			newEnemies.SetActive(true);
			enemyCount = newEnemies.gameObject.transform.childCount;
			cars = newEnemies.gameObject.transform.GetChild(enemyCount -1);
		}

		if (Time.time > increaseDifficulty && increaseDifficulty <=90)
		{
			EnemyVehicle.speed += 0.5f;
			PowerUpScript.speed += 0.5f;
			increaseDifficulty = Time.time + 30;
		}
		if (Time.time > increaseDifficulty && increaseDifficulty > 90 && increaseDifficulty < 5000)
		{
			EnemyVehicle.speed += 0.1f;
			PowerUpScript.speed += 0.1f;
			increaseDifficulty = Time.time + 50;
		}

	}
}
