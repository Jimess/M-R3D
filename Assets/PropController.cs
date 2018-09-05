using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropController : MonoBehaviour {
	private bool _isActive = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PropClick()  {
		if (_isActive) {
			Destroy(gameObject);
		}
	}

	public void PropHover() {
		if (!_isActive) {
			_isActive = true;
		}
	}
}
