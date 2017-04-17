using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float powerUpTime = 5;
	private Vector3 position;
	private bool isPoweredUp = false;
	private float powerupPassed = 0;
	public static bool isAlive;
	public static float playerScore;
	private bool invincible = false;
	private float stopJump = 0;
	public float jumpLength = 0;


	// Use this for initialization
	void Start () {
		position = transform.position;
		isAlive = true;
		Time.timeScale = 1f;
		playerScore = 0;
	}

	void FixedUpdate ()
	{
		if (isPoweredUp) {

			Destroy(GameObject.FindGameObjectWithTag("PowerUp"));

			if (powerupPassed > powerUpTime) {
				Time.timeScale = 1f;
				isPoweredUp = false;
				powerupPassed = 0;
			} else {
				Time.timeScale = 0.5f;
				powerupPassed += Time.deltaTime*2;
			}
		}

		playerScore += Time.deltaTime*10;
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = position;

		if (Input.GetKeyDown(KeyCode.UpArrow) && position.y < 2)
        {
            position = new Vector3(position.x, position.y + 2, position.z);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && position.y > -2)
        {
            position = new Vector3(position.x, position.y -2, position.z);
        }

        if (Input.GetKey(KeyCode.RightArrow) && position.x < 19)
        {
            position = new Vector3(position.x + 10 * Time.deltaTime, position.y, position.z);
        }

        if (Input.GetKey(KeyCode.LeftArrow) && position.x > 1)
        {
            position = new Vector3(position.x - 10 * Time.deltaTime, position.y, position.z);
        }

		//Jumping
		if (Input.GetKeyDown(KeyCode.Space) && !invincible)
		{
			invincible = true;
			stopJump = Time.time + jumpLength;
			Debug.Log("Jumping!");
			//Animation needs to change from player running to player jumping
		}

		if (invincible && Time.time > stopJump)
		{
			invincible = false;
			Debug.Log("Running!");
			//Animation needs to change from player jumping to player running
		}

//		for Pause button
		if (Input.GetKey(KeyCode.P))
		{
//					pause screen here
		}
    }

//	If collided with something
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Enemy" && !invincible) {
//			Debug.Log ("Collided With Enemy");
			isAlive = false;
		} else {
//			Debug.Log ("Collided With PowerUp");
			isPoweredUp = true;
		}
	}
}
