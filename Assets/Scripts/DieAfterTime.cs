using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfterTime : MonoBehaviour {
	public float Lifetime = 1;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, Lifetime);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
