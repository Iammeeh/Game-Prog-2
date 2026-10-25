using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void Start()
    {
        Invoke(nameof(Impact), 2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pointer") || other.CompareTag("Bullet"))
            return;

        if (other.TryGetComponent(out GreenEnemy greenTarget))
        {
            greenTarget.Damage(20);
        }
        else if (other.TryGetComponent(out BlueEnemy blueTarget))
        {
            blueTarget.Damage(20);
        }
        else if (other.TryGetComponent(out PinkEnemy pinkTarget))
        {
            pinkTarget.Damage(20);
        }
        Impact();
        /*        // Try to get the IDamageable interface from the hit object
                IDamageable damageable = other.GetComponent<IDamageable>();

                if (damageable != null)
                {
                    // Pass the bullet's material type to the interface method
                    damageable.TakeDamage(bulletMaterial);
                }

                // Both requirements (5 & 6) specify that the bullet is always destroyed
                Impact();*/
    }
/*    [SerializeField] private colorType bulletMaterial;*/

/*    private void OnTriggerEnter(Collider other)
    {
        // Try to get the IDamageable interface from the hit object
        IDamageable damageable = other.GetComponent<IDamageable>();

        if (damageable != null)
        {
            // Pass the bullet's material type to the interface method
            damageable.TakeDamage(bulletMaterial);
        }

        // Both requirements (5 & 6) specify that the bullet is always destroyed
        Impact();
    }*/


    private void Impact()
    {
        Destroy(gameObject);
    }
} 
