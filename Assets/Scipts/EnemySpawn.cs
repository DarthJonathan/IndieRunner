using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

	private int counter = 0;
	public List<GameObject> enemyPrefabs = new List<GameObject>(0);
	public List<GameObject> enemyPrefabs2 = new List<GameObject>(0);
	private float createEnemies = 0;
	private float createSpeed = 5;
	private float increaseDifficulty = 1;
	private int enemyCount = 0;
	private int boolCount = 0;
	GameObject newEnemies;
	Transform cars;

	void Start ()
	{
		//			New Objects for enemy
		newEnemies = Instantiate (enemyPrefabs [Random.Range (0, enemyPrefabs.Count)]);

		//			Activate the enemy
		newEnemies.SetActive (true);

		enemyCount = newEnemies.gameObject.transform.childCount;
		cars = newEnemies.gameObject.transform.GetChild(enemyCount -1);
	}
	
	// Update is called once per frame
	void Update ()
    {

		//Find each enemy, check if they are left of position 18 x or so.

		if (cars.position.x <10)
		{
			newEnemies = Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Count)]);
			newEnemies.SetActive(true);
			enemyCount = newEnemies.gameObject.transform.childCount;
			cars = newEnemies.gameObject.transform.GetChild(enemyCount -1);
		}

		if (cars.position.x < -2)
		{
			Destroy(newEnemies);
		}

		if (Time.time > increaseDifficulty && increaseDifficulty <=90)
		{
			EnemyVehicle.speed += 0.5f;
			increaseDifficulty = Time.time + 30;
		}
		if (Time.time > increaseDifficulty && increaseDifficulty > 90 && increaseDifficulty < 1000)
		{
			EnemyVehicle.speed += 0.1f;
			increaseDifficulty = Time.time + 50;
		}

	}
}
