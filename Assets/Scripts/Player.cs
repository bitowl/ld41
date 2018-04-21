using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour
{

    public float horizontalSpeed = 10;
    private Rigidbody rb;
    private float horizontalVelocity = 0;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalVelocity = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        rb.velocity = Vector3.right * horizontalVelocity * horizontalSpeed;
    }

    void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
    }
}
