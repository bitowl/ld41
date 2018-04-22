using System.Collections;
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
    public FloatVariable maxAmmo;
    public FloatVariable ammo;
    public float fireCooldown = 0.1f;
    public float minX = -10;
    public float maxX = 10;
    public StringEvent informationBoxEvent;
    public GameEvent gameLostEvent;
    public FloatVariable healthPackHealth;
    public FloatVariable healthPackAmmo;
    public StringEvent audioEvent;


    private Rigidbody rb;
    private float horizontalVelocity = 0;
    private float fireCooldownLeft = 0;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        health.value = maxHealth.value;
        ammo.value = maxAmmo.value;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalVelocity = Input.GetAxis("Horizontal");
        if (Input.GetButton("Fire1"))
        {
            fireCooldownLeft -= Time.deltaTime;
            if (fireCooldownLeft <= 0)
            {
                fireCooldownLeft = fireCooldown;
                Fire();
            }
        }
        else
        {
            fireCooldownLeft = 0;
        }
        if (transform.localPosition.x > maxX)
        {
            transform.localPosition = new Vector3(maxX, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.x < minX)
        {
            transform.localPosition = new Vector3(minX, transform.localPosition.y, transform.localPosition.z);
        }
    }

    void Fire()
    {
        if (ammo.value > 0)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            audioEvent.Raise("shoot");
            ammo.value--;
        }
        else
        {
            audioEvent.Raise("error");
            informationBoxEvent.Raise("Our ammo ran out. We need supplies!");
            fireCooldownLeft = 1;
        }

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
        if (health.value < 0)
        {
            gameLostEvent.Raise();
        }
    }

    public void OnHealthPackReceived()
    {
        ammo.value += healthPackAmmo.value;
        if (ammo.value > maxAmmo.value)
        {
            ammo.value = maxAmmo.value;
        }
        health.value += healthPackHealth.value;
        if (health.value > maxHealth.value)
        {
            health.value = maxHealth.value;
        }
        informationBoxEvent.Raise("We got supplies!");
    }
}
