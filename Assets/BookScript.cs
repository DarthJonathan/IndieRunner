using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookScript : MonoBehaviour {

	private float speed = EnemyVehicle.speed;
	private Vector3 direction = new Vector3(-1, 0, 0);
	
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

		if (collider.gameObject.tag == "PowerUp") {
			speed = 0;
		}
	}

	IEnumerator OnTriggerExit2D(Collider2D collider)
	{
		yield return new WaitForSeconds (0.5f);
		speed = EnemyVehicle.speed;
	}}
