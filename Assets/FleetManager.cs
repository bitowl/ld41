using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetManager : MonoBehaviour {

	public GameObject fleetPrefab;

	private Planet from;
	private Planet to;

	public void PrepareFleet(Planet from, Planet to) {
		this.from = from;
		this.to = to;
	}

	public void SendFleet() {
		Fleet fleet = Instantiate(fleetPrefab).GetComponent<Fleet>();
		fleet.startPosition = from.transform.position;
		fleet.endPosition = to.transform.position;
	}
}
