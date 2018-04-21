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
		PlanetData initialPlanetData = ScriptableObject.CreateInstance<PlanetData>();
		initialPlanetData.belongsToYou = true;
		GameObject initialPlanet = Instantiate(planetPrefab);
		initialPlanet.GetComponent<Planet>().data = initialPlanetData;

		for (int i = 0; i < planetCount; i++) {
			PlanetData planetData = ScriptableObject.CreateInstance<PlanetData>();
			planetData.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
			GameObject planet = Instantiate(planetPrefab);
			planet.GetComponent<Planet>().data = planetData;
		}
	}
	
}
