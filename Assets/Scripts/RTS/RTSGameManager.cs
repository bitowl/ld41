using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTSGameManager : MonoBehaviour {
	public List<Fleet> fleets;
	public Fleet playerFleet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnRoundWon() {
		playerFleet = null;
	}
}
