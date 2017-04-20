using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMainMenu : MonoBehaviour {

	public static bool isAlive = true;
	Vector3 pos;

	// Use this for initialization
	void Start () {

		pos = Camera.main.WorldToViewportPoint(transform.position);
		transform.position = new Vector3 (pos.x + 160, transform.position.y, transform.position.z);
		
	}

	// Update is called once per frame
	void Update () {

		transform.position = new Vector3 (pos.x + 160, transform.position.y, transform.position.z);
		
	}
}
