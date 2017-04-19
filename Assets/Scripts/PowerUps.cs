using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour {

	public List<GameObject> powerupPrefabs = new List<GameObject>(0);
	public float populatePowerUp = 0;

	private float powerUpSpawn = 0;

	
	// Update is called once per frame
	void Update () {

		if (Time.fixedTime > powerUpSpawn) {

			powerUpSpawn = Time.fixedTime + populatePowerUp;

			//PowerUp
			GameObject newPowerUp = Instantiate (powerupPrefabs [Random.Range (0, powerupPrefabs.Count)]);

			newPowerUp.SetActive (true);
		}
		
	}
}
