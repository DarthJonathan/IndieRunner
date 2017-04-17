using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCar : MonoBehaviour {

    public float speed = 5;
    private Vector3 direction = new Vector3(-1, 0, 0);


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.x < -2)
        {
			int childC = gameObject.transform.parent.childCount;


        }
	}
}
