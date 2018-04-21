﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {
    public float verticalSpeed = 10;
	public float maxLifeTime = 5;
    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * verticalSpeed;
		Destroy(gameObject, maxLifeTime);
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
