using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public float verticalSpeed = 10;
    public float maxLifeTime = 5;
    public GameEvent playerDamageEvent;
    public GameEvent enemyDestroyedEvent;

    private Rigidbody rb;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.down * verticalSpeed;
        Destroy(gameObject, maxLifeTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player") {
            playerDamageEvent.Raise();
        }
        Kill();
    }

    void Kill() {
        enemyDestroyedEvent.Raise();
        Destroy(gameObject);
    }
}
