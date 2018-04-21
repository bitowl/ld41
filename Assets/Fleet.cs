﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fleet : MonoBehaviour {
	public Vector3 startPosition;
	public Vector3 endPosition;
	public float velocity = 2;

	// Use this for initialization
	void Start () {
		transform.position = startPosition;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.position + (endPosition - startPosition).normalized * velocity * Time.deltaTime;
		
		if (Vector3.Distance(transform.position,startPosition) >= Vector3.Distance(startPosition, endPosition))  {
			ReachedGoal();
		}
	}

	void ReachedGoal() {
		Destroy(gameObject);
	}
}