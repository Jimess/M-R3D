using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawWithMouse : MonoBehaviour {
	
	public Camera _camera;
	// public Shader _drawShader;
	// private RenderTexture _spaltmap;
	// private Material _sandMaterial, _drawMaterial;
	private RaycastHit _hit;
	private RaycastHit[] _hits;

	// public RenderTexture _temp;

	public LayerMask mask;

	public MouseManager mouseM;

	// Use this for initialization
	void Start () {
		// _drawMaterial = new Material(_drawShader);
		// _drawMaterial.SetVector("_Color", Color.red);
		// _drawMaterial.SetVector("_Coordinate", new Vector4(1,1,0,0));

		// _sandMaterial = GetComponent<MeshRenderer>().material;

		// _spaltmap = new RenderTexture(200,200,0,RenderTextureFormat.ARGBFloat);

		// _sandMaterial.SetTexture("_Splat", _spaltmap);

		_camera = Camera.main;

		mouseM = GameObject.FindGameObjectWithTag("GameController").GetComponent<MouseManager>();
	}
	
	// Update is called once per frame
	void Update () {
		// Mouse UP for picking up props only HAS TO BE BEFORE MOUSEHOLD
		if (Input.GetKeyUp(KeyCode.Mouse0) && mouseM.cdSlider.value < 1f) {
			if (Physics.Raycast(_camera.ScreenPointToRay(Input.mousePosition), out _hit, 500f, mask.value)) {
				if (_hit.collider.gameObject.tag == "Prop") {
					_hit.collider.GetComponent<PropController>().PropClick();
					mouseM.cdSlider.value += 1f/3f;
				}
			}
		}

		if (Input.GetKey(KeyCode.Mouse0)) {
			mouseM.isSwiping = true;


			_hits = (Physics.RaycastAll(_camera.ScreenPointToRay(Input.mousePosition), 500f, mask.value));
			foreach (RaycastHit hit in _hits) {
				
				if (hit.collider.gameObject.tag == "Prop") {
					hit.collider.GetComponent<PropController>().PropHover();
				} else if (mouseM.cdSlider.value < 1f) {
					// 	// MOUSE MANAGER PART
					mouseM.lastPos = mouseM.curPos;
					mouseM.curPos = hit.point;

					DrawTextController textObj;
					textObj = hit.transform.gameObject.GetComponent<DrawTextController>();
					textObj.TextureHit(hit.textureCoord.x, hit.textureCoord.y);

					// Vector4 temp_vec = new Vector4(hit.textureCoord.x, hit.textureCoord.y ,0 ,0);
					// //Debug.Log(temp_vec);
					// _drawMaterial.SetVector("_Coordinate", temp_vec);
					
					// //_drawMaterial.SetVector("Coordinate", new Vector4(_hit.textureCoord.x, _hit.textureCoord.y ,0 ,0));
					// //Debug.Log(_drawMaterial.GetVector("Coordinate"));
					// _temp = RenderTexture.GetTemporary(_spaltmap.width, _spaltmap.height, 0, RenderTextureFormat.ARGBFloat);
					// //RenderTexture temp = RenderTexture.GetTemporary(_spaltmap.width, _spaltmap.height, 0, RenderTextureFormat.ARGBFloat);

					// Graphics.Blit(_spaltmap, _temp);
					// Graphics.Blit(_temp, _spaltmap, _drawMaterial);
					// RenderTexture.ReleaseTemporary(_temp);

				}
			}


		} else {
			mouseM.isSwiping = false;
		}
	}

	void OnGUI() {
	  //GUI.DrawTexture(new Rect(0,0,256,256), _temp, ScaleMode.ScaleToFit, false, 1);
      //GUI.DrawTexture(new Rect(0,0,256,256), _spaltmap, ScaleMode.ScaleToFit, false, 1);
	  //GUI.DrawTexture(new Rect(0,0,256,256), _sandMaterial.GetTexture("_Splat"), ScaleMode.ScaleToFit, false, 1);
	}
}
