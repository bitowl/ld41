using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    public float verticalSpeed = 10;
    public float maxLifeTime = 5;
    public GameEvent playerDamageEvent;
    public FloatGameEvent getCashEvent;
    public EnemyEvent enemyDestroyedEvent;
    public float cashWhenKilled = 2;
    public float startHealth = 3;

    private Rigidbody rb;
    private float health;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.down * verticalSpeed;
        // Destroy(gameObject, maxLifeTime);
        health = startHealth;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player") {
            playerDamageEvent.Raise();
            Kill();
        } else if (other.gameObject.tag == "Bullet") {
            health--;
            if (health <= 0) {
                getCashEvent.Raise(cashWhenKilled);
                Kill();
            }
        } else if (other.gameObject.tag == "EnemyDestroyer") {
            Kill();
        } else {
            Debug.LogWarning("Enemy collided with unknown " + other.gameObject);
        }
    }

    void Kill() {
        EnemyEventData data = ScriptableObject.CreateInstance<EnemyEventData>();
        data.enemy = this;
        enemyDestroyedEvent.Raise(data);
        Destroy(gameObject);
    }
}
