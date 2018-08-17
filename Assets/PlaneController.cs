using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProceduralToolkit.Examples;

public class PlaneController : MonoBehaviour {

    public GameObject plane;
    public int counter = 3;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < counter; i++)
        {
            Instantiate(plane, new Vector3(0, 0, -i * plane.GetComponent<LowPolyTerrainGeneratorConfigurator>().config.terrainSize.z), transform.rotation);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreatePlane()
    {
        Instantiate(plane, new Vector3(0,0, -counter* plane.GetComponent<LowPolyTerrainGeneratorConfigurator>().config.terrainSize.z), transform.rotation);
        counter++;
    }
}
