using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMap : MonoBehaviour {

	[System.Serializable]
	public class LevelStruct {
		public string number;
		public string layerName;
		public string collType;
		public int numberOfObjects;
		public GameObject prefab;
	}

	public GameObject prefab;
	public LevelStruct[] layers;

	[Header("Spawn Place Properties")]
	public float planeX = 10f;
	// is going to adapt based on the prefab
	private float planeY = 2f;
	public float planeZ = 40f;
	public float baseOffset = 4f;

	[Header("Object Generation Properties")]
	public int numOfRocks = 20;

	private float tempGizmoHeight;
	private float tempGizmoPosY;


	// Use this for initialization
	void Start () {
		GameObject curPrefab;
		int curObjectCount;
		
		float lastPrefabHeight = 0f;
		for (int i = 0; i < layers.Length; i++) {
			curPrefab = layers[i].prefab;
			curObjectCount = layers[i].numberOfObjects;

			float prefabHeight = 0f;

			float x,y,z;
			float prefabX = 0f;
			float prefabY = 0f; 
			float prefabZ = 0f;

			//get size of the objectspawn
			if (layers[i].collType == "Box") {
				prefabHeight = curPrefab.GetComponent<BoxCollider>().size.y * curPrefab.transform.localScale.y;

				//get prefab sizes
				prefabX = curPrefab.GetComponent<BoxCollider>().size.x * curPrefab.transform.localScale.x;
				prefabY = curPrefab.GetComponent<BoxCollider>().size.y * curPrefab.transform.localScale.y;
				prefabZ = curPrefab.GetComponent<BoxCollider>().size.z * curPrefab.transform.localScale.z;
			} else if (layers[i].collType == "Sphere") {
				prefabHeight = curPrefab.GetComponent<SphereCollider>().radius;

				prefabX = curPrefab.GetComponent<SphereCollider>().radius * curPrefab.transform.localScale.x;
				prefabY = curPrefab.GetComponent<SphereCollider>().radius * curPrefab.transform.localScale.y;
				prefabZ = curPrefab.GetComponent<SphereCollider>().radius * curPrefab.transform.localScale.z;
			}

			planeY = prefabHeight;

			for (int j = 0; j < curObjectCount; j++) {
				x = Random.Range(transform.position.x - planeX/2 + prefabX/2, transform.position.x + planeX/2 - prefabX/2);
				y = Random.Range(transform.position.y + baseOffset - prefabY/2 + prefabY/2, transform.position.y + baseOffset + planeY/2 - prefabY/2) + (lastPrefabHeight + prefabHeight/2);
				z = Random.Range(transform.position.z - planeZ/2 + prefabZ/2, transform.position.z + planeZ/2 - prefabZ/2);

				Instantiate(curPrefab, new Vector3(x,y,z), curPrefab.transform.rotation);
			}
			lastPrefabHeight += prefabHeight;
		}

		// float x,y,z;
		// float prefabX, prefabY, prefabZ;

		// //get prefab sizes
		// prefabX = prefab.GetComponent<BoxCollider>().size.x;
		// prefabY = prefab.GetComponent<BoxCollider>().size.y;
		// prefabZ = prefab.GetComponent<BoxCollider>().size.z;

		// planeY = prefabY;

		// for (int i = 0; i < numOfRocks; i++) {

		// 	x = Random.Range(transform.position.x - planeX/2 + prefabX/2, transform.position.x + planeX/2 - prefabX/2);
		// 	y = Random.Range(transform.position.y + baseOffset - planeY/2 + prefabY/2, transform.position.y + baseOffset + planeY/2 - prefabY/2);
		// 	z = Random.Range(transform.position.z - planeZ/2 + prefabZ/2, transform.position.z + planeZ/2 - prefabZ/2);

		// 	Instantiate(prefab, new Vector3(x,y,z), prefab.transform.rotation);
		// }
	}
	
	// Update is called once per frame
	void Update () {
		// if (Input.GetKeyUp(KeyCode.Space)) {
		// 	float x,y,z;
		// 	float prefabX, prefabY, prefabZ;

		// 	prefabX = prefab.GetComponent<BoxCollider>().size.x;
		// 	prefabY = prefab.GetComponent<BoxCollider>().size.y;
		// 	prefabZ = prefab.GetComponent<BoxCollider>().size.z;

		// 	x = Random.Range(transform.position.x - planeX/2 + prefabX/2, transform.position.x + planeX/2 - prefabX/2);
		// 	y = Random.Range(transform.position.y + offsetY - 1 + prefabY/2, transform.position.y + offsetY + 1 - prefabY/2);
		// 	z = Random.Range(transform.position.z - planeZ/2 + prefabZ/2, transform.position.z + planeZ/2 - prefabZ/2);

		// 	Instantiate(prefab, new Vector3(x,y,z), prefab.transform.rotation);
		// }
	}

	void OnDrawGizmos() {
		// spawn space
		//Gizmos.DrawCube(transform.position + new Vector3(0, baseOffset, 0), new Vector3(planeX,planeY,planeZ));
		// for (int i = 0; i < layers.Length; i++) {
		// 	Gizmos.color = Color.cyan;
		// 	Gizmos.DrawCube(transform.position + new Vector3(0, baseOffset + tempGizmoPosY, 0), new Vector3(planeX,tempGizmoHeight,planeZ));
		// }
	}
}
