using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Vector3 position;

    public float powerUpTime = 5;
    private bool isPoweredUp = false;
	private float powerupPassed = 0;

	public static bool isAlive;
	public static float playerScore;

	private bool invincible = false;
	private float stopJump = 0;
	public float jumpLength;
	private bool hopping = false;
	Animator animator;

    private Vector3 endPos;
    private float timer = 0;

    private lanes lane;

	public GUIStyle ScoreBox;

	private AudioSource source;
	public AudioClip bgm;
	public AudioClip runningSound;
	public AudioClip trafficSound;
	public AudioClip carHorn;
	private float runningTimer;
	private float trafficTimer;

	// Use this for initialization
	void Start () {
		position = transform.position;
		isAlive = true;
		Time.timeScale = 1f;
		playerScore = 0;

		animator = GetComponent<Animator> ();
        endPos = transform.position;

        lane = lanes.lane2;

		source = GetComponent<AudioSource> ();
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

        if (lane == lanes.lane1)
        {
            position = new Vector3(position.x, 5, position.z);
        }

        if (lane == lanes.lane2)
        {
            position = new Vector3(position.x, 0, position.z);
        }

        if (lane == lanes.lane3)
        {
            position = new Vector3(position.x, -5, position.z);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch(lane)
            {
                case lanes.lane1:
                    break;
                case lanes.lane2:
                    lane = lanes.lane1;
                    break;
                case lanes.lane3:
                    lane = lanes.lane2;
                    break;
                default:
                    lane = lanes.lane2;
                    break;
            }               
        }

		if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            switch (lane)
            {
                case lanes.lane1:
                    lane = lanes.lane2;
                    break;
                case lanes.lane2:
                    lane = lanes.lane3;
                    break;
                case lanes.lane3:
                    break;
                default:
                    lane = lanes.lane2;
                    break;
            }
        }

		if (Input.GetKey(KeyCode.RightArrow) && position.x < 23)
        {
                position = new Vector3(position.x + 15 * Time.deltaTime, position.y, position.z);
        }

		if (Input.GetKey(KeyCode.LeftArrow) && position.x > -5)
        {
                position = new Vector3(position.x - 15 * Time.deltaTime, position.y, position.z);
        }


//		Running sound
		if (Time.time > runningTimer - 2.3f) {
			runningTimer = Time.time + runningSound.length;
			source.PlayOneShot (runningSound);
		}

//		traffic sound
		if (Time.time > trafficTimer) {
			trafficTimer = Time.time + trafficSound.length;
			source.PlayOneShot (trafficSound);
		}
			

        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && !invincible)
		{
			invincible = true;
			stopJump = Time.time + jumpLength;
			animator.SetTrigger ("isJumping");

            timer = 0.0f;
            endPos = position;

        }
        if (timer <= 1)
        {
            timer += Time.deltaTime / 0.75f;
            var height = Mathf.Sin(Mathf.PI * timer) * 4f;
            position = Vector3.Lerp(position, endPos, timer) + Vector3.up * height;

            if (Input.GetKeyDown(KeyCode.UpArrow) && position.y < 5)
            {
                endPos = new Vector3(position.x, position.y + 5 * Time.deltaTime, position.z);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && position.y > -5)
            {
                endPos = new Vector3(position.x, position.y - 5 * Time.deltaTime, position.z);
            }
            if (Input.GetKey(KeyCode.RightArrow) && position.x < 23)
            {
                endPos = new Vector3(position.x + 15 * Time.deltaTime, position.y - height, position.z);
            }

            if (Input.GetKey(KeyCode.LeftArrow) && position.x > -5)
            {
                endPos = new Vector3(position.x - 15 * Time.deltaTime, position.y - height, position.z);
            }
        }

        if (invincible && Time.time > stopJump)
		{
			invincible = false;
		}
    }

	void OnGUI ()
	{
		//Jumping counter
		if (Time.time < stopJump && invincible) {
			GUI.Box(new Rect(Screen.width/2 - 40,20,80,50), (stopJump - Time.time).ToString("f0"), ScoreBox);
		}
	}

//	If collided with something
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Enemy" && !invincible) {
//			Debug.Log ("Collided With Enemy");
			source.PlayOneShot(carHorn);
			isAlive = false;
		} else if(collider.tag == "PowerUp"){
//			Debug.Log ("Collided With PowerUp");
			isPoweredUp = true;
		}
	}

    public enum lanes
    {
        lane1,
        lane2,
        lane3
    }
}
