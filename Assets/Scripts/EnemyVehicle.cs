using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVehicle : MonoBehaviour {

    public static float speed = 10;
    private Vector3 direction = new Vector3(-1, 0, 0);


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.x < -20)
        {
            int childC = gameObject.transform.parent.childCount;

            if ( childC == 1 ||
                 childC == 2 && gameObject.transform.parent.GetChild(childC -1).position.x == gameObject.transform.parent.GetChild(childC -2).position.x  ||
                 childC == 3 && gameObject.transform.parent.GetChild(childC - 1).position.x == gameObject.transform.parent.GetChild(childC - 2).position.x && gameObject.transform.parent.GetChild(childC - 3).position.x == gameObject.transform.parent.GetChild(childC - 1).position.x)
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
