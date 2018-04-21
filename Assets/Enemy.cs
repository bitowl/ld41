using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public float verticalSpeed = 10;
    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.down * verticalSpeed;
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
