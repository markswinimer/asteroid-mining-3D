using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0.5f;
    public float damage = 10f;
    public float force = 100f;
    public float range = 100f;

    [SerializeField] private Transform firePointTransform;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private GameObject fireEffect;
    [SerializeField] private AudioSource shootSound;

    public void PrimaryAction()
    {
        // Instantiate the bullet at the fire point position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePointTransform.position, firePointTransform.rotation);

        // Apply force in the forward direction of the fire point for 3D movement
        Vector3 forceDirection = firePointTransform.forward * force;
        bullet.GetComponent<Bullet>().AddForce(forceDirection);

        // Optionally, play the fire effect and sound
        if (fireEffect != null)
        {
            Instantiate(fireEffect, firePointTransform.position, firePointTransform.rotation);
        }

        if (shootSound != null)
        {
            shootSound.Play();
        }
    }

    public void SecondaryAction()
    {
        // Define secondary action behavior here, if any
    }
}
