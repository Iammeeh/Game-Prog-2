using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class EnemyBase : MonoBehaviour
{
    [Header("Enemy Attributes")]
    [SerializeField] protected Transform target;

    /*    [SerializeField] protected float speed = 5f;*/
    protected virtual void Update()
    {
        //Find the vector pointing to the target (destination - origin)
        Vector3 directionToTarget = target.position - transform.position;

        // Check distance so we dont vibrate around the  target
        if (directionToTarget.magnitude > 0.1f)
        {
            // Normalize the direction and apply the movement
            Vector3 normalizedDirection = directionToTarget.normalized;
            transform.position += normalizedDirection * moveSpeed * Time.deltaTime;
            // Ensures the movement is smooth regardless of the computers frame rate
        }
    }
    /*
        protected virtual void OnCollisionEnter(Collision other)
        {
            Debug.Log($"{gameObject.name} has died:(");
            Destroy(this.gameObject);
        }*/
    [Header("Base Actor Attributes")]
    [SerializeField] protected float maxHealth = 10f;
    protected float currentHealth;
    [SerializeField] protected float moveSpeed = 3f;
    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }
    /*public virtual void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log($"{gameObject.name} took {damageAmount}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }*/

    public virtual void TakeDamage(float damageAmount)
    {
        currentHealth = Mathf.Max(0, currentHealth - damageAmount);
        if (currentHealth <= 0)
        {
            Die();
        }
    }
    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} has been vanquished from their mortal shell");
        Destroy(gameObject);
    }
}