using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

	public static float speed = 10;
	private Vector3 direction = new Vector3(-1, 0, 0);

	// Use this for initialization
	void Start () {

		speed = EnemyVehicle.speed;

	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(direction * speed * Time.deltaTime);

		if (transform.position.x < -25)
		{
			Destroy (gameObject);
		}
		
	}

	void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Enemy")
		{
			speed = 0;
			Debug.Log ("Here");
		}
		Debug.Log (collider);
	}

	IEnumerator OnTriggerExit2D(Collider2D collider)
	{
		yield return new WaitForSeconds (0.5f);
		speed = EnemyVehicle.speed;
	}
}
