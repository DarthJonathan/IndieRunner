using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookSpawner : MonoBehaviour {
	
	public List<GameObject> powerupPrefabs = new List<GameObject>(0);
	public float populate = 0;

	private float spawn = 0;
	private float[] y = new float[3];

	void Start ()
	{
		y[0] = -5;
		y[1] = 0;
		y[2] = 5;
	}


	// Update is called once per frame
	void Update () {

		if (Time.fixedTime > spawn) {

			spawn = Time.fixedTime + Random.Range(1,5);

			//PowerUp
			GameObject newPowerUp = Instantiate (powerupPrefabs [Random.Range (0, powerupPrefabs.Count)]);

			newPowerUp.transform.position = new Vector3 (newPowerUp.transform.position.x+10, y [Random.Range (0, 2)], newPowerUp.transform.position.z);

			newPowerUp.SetActive (true);
		}

	}
}
