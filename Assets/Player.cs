using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float jumpLength = 0;

	private Vector3 position;
    private bool invincible = false;
    private float stopJump = 0;
    

	// Use this for initialization
	void Start () {
		position = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

        transform.position = position;

        //Movement
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
    }
}
