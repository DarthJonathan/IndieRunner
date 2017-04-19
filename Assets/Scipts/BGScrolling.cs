using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScrolling : MonoBehaviour {

    public float speed = 0;
    public Vector3 direction;

    private Vector3 startPos;
    private float newPos;


	// Use this for initialization
	void Start () {
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        newPos = Mathf.Repeat(Time.time * speed, GetComponent<SpriteRenderer>().bounds.size.x);
        transform.position = startPos + direction * newPos;
	}
}
