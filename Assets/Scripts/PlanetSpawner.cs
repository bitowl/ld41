using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetSpawner : MonoBehaviour {
	public float minX = -10;
	public float maxX = 10;
	public float minY = -10;
	public float maxY = 10;
	public float planetCount = 10;
	public GameObject planetPrefab;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < planetCount; i++) {
			GameObject planet = Instantiate(planetPrefab);
			planet.transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
		}
	}
	
}
