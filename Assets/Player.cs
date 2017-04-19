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
	public float jumpLength;
	private bool hopping = false;
	Vector3 jumpingPos;
	Animator animator;


	// Use this for initialization
	void Start () {
		position = transform.position;
		isAlive = true;
		Time.timeScale = 1f;
		playerScore = 0;
		jumpingPos = position;

		animator = GetComponent<Animator> ();
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

		if (Input.GetKeyDown(KeyCode.UpArrow) && position.y < 5 && !invincible)
        {
            position = new Vector3(position.x, position.y + 5, position.z);
        }

		if (Input.GetKeyDown(KeyCode.DownArrow) && position.y > -5 && !invincible)
        {
            position = new Vector3(position.x, position.y -5, position.z);
        }

		if (Input.GetKey(KeyCode.RightArrow) && position.x < 23 && !invincible)
        {
            position = new Vector3(position.x + 15 * Time.deltaTime, position.y, position.z);
        }

		if (Input.GetKey(KeyCode.LeftArrow) && position.x > -6 && !invincible)
        {
            position = new Vector3(position.x - 15 * Time.deltaTime, position.y, position.z);
        }

		//Jumping
		if (Input.GetKeyDown(KeyCode.Space) && !invincible)
		{
			invincible = true;
			stopJump = Time.time + jumpLength;
			animator.SetTrigger ("isJumping");

//			Jumping animation
			StartCoroutine (isJumping (0.75f, 5f));
		}
			

		if (invincible && Time.time > stopJump)
		{
			invincible = false;
		}
    }

//	Jumping jump animation
	IEnumerator isJumping (float time, float hopHeight)
	{
		if(hopping) yield break;

		hopping = true;
		var startPos = transform.position;
		Vector3 endPos = transform.position;
		endPos.x += 3;
		var timer = 0.0f;

		while (timer <= 1.0f) {
			var height = Mathf.Sin(Mathf.PI * timer) * hopHeight;
			transform.position = Vector3.Lerp(startPos, endPos, timer) + Vector3.up * height; 

			timer += Time.deltaTime / time;
			yield return null;
		}
		hopping = false;
	}

	void OnGUI ()
	{
		//Jumping counter
		if (Time.time < stopJump && invincible) {
			GUI.Box(new Rect(Screen.width/2 - 40,20,80,50), (stopJump - Time.time).ToString("f0"));
		}
	}

//	If collided with something
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Enemy" && !invincible) {
//			Debug.Log ("Collided With Enemy");
			isAlive = false;
		} else if(collider.tag == "PowerUp"){
//			Debug.Log ("Collided With PowerUp");
			isPoweredUp = true;
		}
	}
}
