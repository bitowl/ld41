using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    public float verticalSpeed = 10;
    public float maxLifeTime = 5;
    public GameObject dieExplosionParticles;

    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.up * verticalSpeed;
        Destroy(gameObject, maxLifeTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            Instantiate(dieExplosionParticles, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else
        {
            Debug.LogWarning("Collided with unknown object" + other);
        }

    }
}
