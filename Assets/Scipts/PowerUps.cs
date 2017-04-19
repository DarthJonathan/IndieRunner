using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

	public List<GameObject> powerupPrefabs = new List<GameObject>(0);
	public float populatePowerUp = 0;

	private float powerUpSpawn = 0;
	private float[] y = new float[3];

	void Start ()
	{
		y[0] = -5;
		y[1] = 0;
		y[2] = 5;
	}

	
	// Update is called once per frame
	void Update () {

		if (Time.fixedTime > powerUpSpawn) {

			powerUpSpawn = Time.fixedTime + populatePowerUp;

			//PowerUp
			GameObject newPowerUp = Instantiate (powerupPrefabs [Random.Range (0, powerupPrefabs.Count)]);

			newPowerUp.transform.position = new Vector3 (newPowerUp.transform.position.x, y [Random.Range (0, 2)], newPowerUp.transform.position.z);

			newPowerUp.SetActive (true);
		}
		
	}
}
