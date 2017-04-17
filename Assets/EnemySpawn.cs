using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour {

    public List<GameObject> enemyPrefabs = new List<GameObject>(0);
	GameObject newEnemies;
	Transform cars;
	private int counter = 0;

	void Start ()
	{
		//			New Objects for enemy
		newEnemies = Instantiate (enemyPrefabs [Random.Range (0, enemyPrefabs.Count)]);

		//			Activate the enemy
		newEnemies.SetActive (true);

		cars = newEnemies.gameObject.transform.GetChild (2);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (cars.position.x < 12) 
		{
//			New Objects for enemy
			newEnemies = Instantiate (enemyPrefabs [Random.Range (0, enemyPrefabs.Count)]);

//			Activate the enemy
			newEnemies.SetActive (true);

//			spawn new enemies on certain point
			counter = newEnemies.gameObject.transform.childCount;
			cars = newEnemies.gameObject.transform.GetChild (counter - 1);
		}
	}
}
