using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    private float _damage = 40f;
    private Rigidbody rb;
    public GameObject impactEffect;

    private float _timeToLive = 2f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        // Initialize the bullet's movement in the forward direction
        rb.linearVelocity = transform.forward * speed;
    }

    void Update()
    {
        // Decrease the bullet's lifespan
        _timeToLive -= Time.deltaTime;
        if (_timeToLive <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddForce(Vector3 forceDirection)
    {
        // Apply force in the specified direction
        rb.AddForce(forceDirection, ForceMode.Impulse);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Bullet collided with " + other.name);
        IDamageable target = other.GetComponent<IDamageable>();

        // Create an impact effect
        if (impactEffect != null)
        {
            GameObject impactEffectVFX = Instantiate(impactEffect, transform.position, Quaternion.identity);
            Destroy(impactEffectVFX, 2f);
        }

        // Apply damage if the target implements IDamageable
        if (target != null)
        {
            target.TakeDamage(_damage);
        }

        // Destroy the bullet regardless of the target
        Destroy(gameObject);
    }
}
