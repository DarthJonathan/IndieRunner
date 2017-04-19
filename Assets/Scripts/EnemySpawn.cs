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
            
                //			New Objects for enemy
                newEnemies = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)]);

                //			Activate the enemy
                newEnemies.SetActive(true);

                enemyCount = newEnemies.gameObject.transform.childCount;
                cars = newEnemies.gameObject.transform.GetChild(enemyCount - 1);
       

            if (Time.time > increaseDifficulty && increaseDifficulty <= 50)
            {
                EnemyVehicle.speed += 1.0f;
                increaseDifficulty += 10;
                Debug.Log(EnemyVehicle.speed);
            }
            else if (Time.time > increaseDifficulty && increaseDifficulty > 50 && increaseDifficulty < 5000)
            {
                EnemyVehicle.speed += 0.5f;
                increaseDifficulty += 20;
                Debug.Log(EnemyVehicle.speed);

            }

        }


	}
}
