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
                Fire();
                fireCooldownLeft = fireCooldown;
            }
        }
        else
        {
            fireCooldownLeft = 0;
        }
        if (transform.localPosition.x > maxX) {
            transform.localPosition = new Vector3(maxX, transform.localPosition.y, transform.localPosition.z);
        }
        if (transform.localPosition.x < minX) {
            transform.localPosition = new Vector3(minX, transform.localPosition.y, transform.localPosition.z);
        }
    }

    void Fire()
    {
        if (ammo.value > 0)
        {
            Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            ammo.value--;
        }
        else
        {
            informationBoxEvent.Raise("Our ammo ran out. We need supplies!");
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
        Debug.Log("Health is now " + health.value);
    }
}
