using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTrigger : MonoBehaviour {

    private PlaneController _planeController;

	// Use this for initialization
	void Start () {
        _planeController = GameObject.Find("GM").GetComponent<PlaneController>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "MainCamera")
        {
            Debug.Log("Veikia"+other.transform.name);
            _planeController.CreatePlane();
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == "MainCamera")
        {
            Destroy(gameObject);
        }

    }
}
