using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleet : MonoBehaviour {
	public Vector3 startPosition;
	public Vector3 endPosition;
	public Planet targetPlanet;
	public float progress = 0.1f;
	// public float velocity = 2;
	public PlanetEvent capturePlanetEvent;

	// Use this for initialization
	void Start () {
		transform.position = startPosition;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dir = (endPosition - startPosition);

		float wholeLength = dir.magnitude;
		float lengthWithoutPlanets = dir.magnitude - targetPlanet.radius * 2; // TODO: Fix here if planets have different radius
		float factor = (progress * lengthWithoutPlanets + targetPlanet.radius)/wholeLength;
		transform.position = startPosition + factor * dir;
		
		if (progress >= 1) {

		}
		/*if (Vector3.Distance(transform.position,startPosition) >= Vector3.Distance(startPosition, endPosition))  {
			ReachedGoal();
		}*/
	}

	void ReachedGoal() {
		PlanetEventData data = ScriptableObject.CreateInstance<PlanetEventData>();
		data.planet = targetPlanet;
		capturePlanetEvent.Raise(data);
		Destroy(gameObject);
	}
}
