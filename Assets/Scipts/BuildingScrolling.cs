using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScrolling : MonoBehaviour {

	Vector3 startPlace;
	public float speed;

	void Start ()
	{
		startPlace = new Vector3 (45, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < -18 && Player.isAlive) {
			transform.position = startPlace;
		} else if(Player.isAlive){
			transform.position = new Vector3 (transform.position.x - speed, transform.position.y, transform.position.z);
		}
		
	}
}
