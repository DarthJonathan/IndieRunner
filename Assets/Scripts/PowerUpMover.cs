﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMover : MonoBehaviour {

	public static float speed = 10;
	private Vector3 direction = new Vector3(-1, 0, 0);

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate(direction * speed * Time.deltaTime);

		if (transform.position.x < -2)
		{
			Destroy(gameObject);
		}
		
	}
}
