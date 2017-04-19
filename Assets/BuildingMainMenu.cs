using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingMainMenu : MonoBehaviour {

	Vector3 startPlace;
	public float speed;
	public float startX;
	public float endX;

	void Start ()
	{
		startPlace = new Vector3 (startX, transform.position.y, transform.position.z);
	}

	// Update is called once per frame
	void Update () {

		if (transform.position.x < endX) {
			transform.position = startPlace;
		} else{
			transform.position = new Vector3 (transform.position.x - speed, transform.position.y, transform.position.z);
		}

	}
}
