using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseManager : MonoBehaviour {

	Vector3 dir;
	public Vector3 lastPos, curPos;
	public float offsetY;

	public Slider cdSlider;

	public ParticleSystem particles;
	ParticleSystem.EmissionModule em;
	Transform partTransform;
	public bool isSwiping = false;

	// Use this for initialization
	void Start () {
		partTransform = particles.GetComponent<Transform>();
		cdSlider.value = 0f;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (curPos != lastPos) {
		dir = curPos - lastPos;
		dir.y = 0;
		partTransform.position = new Vector3(curPos.x, curPos.y + offsetY, curPos.z);
		partTransform.LookAt(partTransform.position + dir);
		}

		em = particles.emission;
		
		// if (isSwiping && !particles.isPlaying) {
		// 	//particles.Play();
			
		// 	//em.rateOverTime = 500;
		// } else if (!isSwiping && particles.isPlaying) {
		// 	//particles.Stop();
		// 	//em.rateOverTime = 0;
		// }

		if (isSwiping) {
			if (cdSlider.value < 1f) {
				particles.Emit(5);
			}
			cdSlider.value += (1f/3 * Time.deltaTime);
		} else {
			cdSlider.value -= (1f/3 * Time.deltaTime);
		}

		// if (Input.GetKeyUp(KeyCode.Space) && particles.isPlaying) {
		// 	particles.Stop();
		// } else if (Input.GetKeyUp(KeyCode.Space) && !particles.isPlaying) {
		// 	particles.Play();
		// }
	}

	void LateUpdate() {
		
	}

	void OnGUI (){
		GUI.Label(new Rect(10, 80, 100, 20), curPos.ToString());
		GUI.Label(new Rect(10, 100, 100, 20), lastPos.ToString());
		GUI.Label(new Rect(10, 120, 100, 20), dir.ToString());
	}
}
