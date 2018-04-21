using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FleetManager : MonoBehaviour {

	public GameObject fleetPrefab;

	public void SendFleet(Planet from, Planet to) {
		Fleet fleet = Instantiate(fleetPrefab).GetComponent<Fleet>();
		fleet.startPosition = from.transform.position;
		fleet.endPosition = to.transform.position;
	}

	public void SendFleet(FleetDataEventData data) {
		SendFleet(data.from, data.to);
	}
}
