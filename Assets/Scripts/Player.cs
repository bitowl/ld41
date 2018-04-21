﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{

    public float horizontalSpeed = 10;
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public FloatVariable maxHealth;
    public FloatVariable health;


    private Rigidbody rb;
    private float horizontalVelocity = 0;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health.value = maxHealth.value;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalVelocity = Input.GetAxis("Horizontal");
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
    }

    void Fire()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    void FixedUpdate()
    {
        rb.velocity = Vector3.right * horizontalVelocity * horizontalSpeed;
    }

    void OnTriggerEnter(Collider other)
    {
    }

    public void OnDamaged()
    {
        health.value -= 1;
        Debug.Log("Health is now " + health.value);
    }
}
