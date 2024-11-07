using UnityEngine;

public class Asteroid : MonoBehaviour, IDamageable
{
    public float health = 10f;
    public float damage = 10f;
    public float force = 0.2f;

    private Rigidbody rb;  // Changed to Rigidbody for 3D
    public GameObject impactEffect;
    public GameObject destroyEffect;

    [SerializeField] private Ore _ore;
    private int _avgOreDrop = 3;

    void Awake()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
    }
    public void AddForce(Vector3 forceDirection)
    {
        rb.AddForce(forceDirection, ForceMode.Impulse);  // Changed to ForceMode for 3D
    }

    // When a ship collides with this
    void OnCollisionEnter(Collision other)  // Changed to OnCollisionEnter for 3D
    {
        // Debug.Log("other collided with " + other.gameObject.name);
        // IDamageable target = other.gameObject.GetComponent<IDamageable>();

        // // Instantiate the impact effect
        // if (impactEffect != null)
        // {
        //     GameObject impactEffectVFX = Instantiate(impactEffect, transform.position, transform.rotation);
        //     Destroy(impactEffectVFX, 2f);
        // }

        // // Apply damage with force if the target implements IDamageable
        // if (target != null)
        // {
        //     target.TakeDamage(damage);
        // }
    }

    public void TakeDamage(float damage)
    {
        Debug.Log("Asteroid taking damage");
        health -= damage;
        if (health <= 0)
        {
            HandleDestroy();
        }
    }

    void HandleDestroy()
    {
        // Drop ore
        for (int i = 0; i < _avgOreDrop; i++)
        {
            Ore ore = Instantiate(_ore, transform.position, transform.rotation);
            // Apply a small random force to each ore
            Vector3 randomForce = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)) * force;
            ore.ApplyForce(randomForce);
        }

        // Instantiate the destroy effect
        if (destroyEffect != null)
        {
            GameObject destroyEffectVFX = Instantiate(destroyEffect, transform.position, transform.rotation);
            Destroy(destroyEffectVFX, 4f);
        }

        // Destroy the asteroid
        Destroy(gameObject);
    }
}