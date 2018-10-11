using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTextController : MonoBehaviour {
    public Shader _drawShader;
	private RenderTexture _spaltmap;
	private Material _sandMaterial, _drawMaterial;
	public RenderTexture _temp;
	// Use this for initialization
	void Start () {
		_drawMaterial = new Material(_drawShader);
		_drawMaterial.SetVector("_Color", Color.red);
		_drawMaterial.SetVector("_Coordinate", new Vector4(1,1,0,0));

		_sandMaterial = GetComponent<MeshRenderer>().material;

		_spaltmap = new RenderTexture(200,200,0,RenderTextureFormat.ARGBFloat);

		_sandMaterial.SetTexture("_Splat", _spaltmap);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TextureHit(float x, float y) {
		Vector4 temp_vec = new Vector4(x, y ,0 ,0);
		//Debug.Log(temp_vec);
		_drawMaterial.SetVector("_Coordinate", temp_vec);
		_temp = RenderTexture.GetTemporary(_spaltmap.width, _spaltmap.height, 0, RenderTextureFormat.ARGBFloat);
		//RenderTexture temp = RenderTexture.GetTemporary(_spaltmap.width, _spaltmap.height, 0, RenderTextureFormat.ARGBFloat);

		Graphics.Blit(_spaltmap, _temp);
		Graphics.Blit(_temp, _spaltmap, _drawMaterial);
		RenderTexture.ReleaseTemporary(_temp);
	}
}
