using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public float speed = 0.02f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		

	}

    private void FixedUpdate()
    {
        //transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Vector3.forward.z * speed);
        transform.position = transform.position - Vector3.forward * speed;
       
    }
}   
