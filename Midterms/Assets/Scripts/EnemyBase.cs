using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public abstract class EnemyBase : MonoBehaviour, IDamageable
{
    [Header("Enemy Attributes")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float maxHealth = 10f;
    protected float currentHealth;
    [SerializeField] protected float moveSpeed = 3f;
/*    [SerializeField] Renderer colorRenderer;*/
/*    [Header("Color Settings")]*/
    /*[SerializeField] private colorType enemyMaterial;

    public void TakeDamage(colorType bulletMaterial)
    {
        // 5. Matching Material: If materials match, destroy the enemy
        if (bulletMaterial == enemyMaterial)
        {
            Debug.Log($"{gameObject.name} was hit by matching material and destroyed!");
            Destroy(gameObject);
        }
        else
        {
            // 6. Wrong Material: Enemy ignores the damage
            Debug.Log($"{gameObject.name} ignored damage from a different material.");
        }
    }*/
    /*    protected virtual void Start()
        {
            colorRenderer = GetComponent<Renderer>();
        }*/
    /*    protected virtual void SameColor(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Renderer>(out Renderer otherRenderer))
            {
                // Compare the primary material colors
                if (colorRenderer.material.color == otherRenderer.material.color)
                {
                    // Destroy the other object first, then this object
                    Destroy(collision.gameObject);
                    Destroy(gameObject);
                }
            }
        }*/

/*    protected virtual void SameColor(Collision collision)
    {
        // 1. Filter out unwanted collisions right away
        if (collision.gameObject.CompareTag("Pointer") || collision.gameObject.CompareTag("Bullet"))
            return;

        // 2. Cache our own renderer and the other object's renderer
        if (TryGetComponent<Renderer>(out Renderer myRenderer) &&
            collision.gameObject.TryGetComponent<Renderer>(out Renderer otherRenderer))
        {
            // 3. Compare the runtime material color instances
            if (myRenderer.material == otherRenderer.material)
            {
                // Colors match: Destroy BOTH enemy and bullet
                Destroy(collision.gameObject);
                Destroy(gameObject);
                return; // Exit early since this object is now being destroyed
            }
        }
        // 4. Fallback: Colors didn't match, or target had no renderer. Only destroy the bullet.
        Destroy(gameObject);
    }*/

    public virtual void Damage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log($"{gameObject.name} took {damageAmount}");

        if (currentHealth <= 0)
        {
            Die();
        }
    }
    protected virtual void Update()
    {
        Vector3 directionToTarget = target.position - transform.position;
        if (directionToTarget.magnitude > 0.1f)
        {
            Vector3 normalizedDirection = directionToTarget.normalized;
            transform.position += normalizedDirection * moveSpeed * Time.deltaTime;
        }
    }
   

    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    protected virtual void Die()
    {
        Debug.Log($"{gameObject.name} has been vanquished from their mortal shell");
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the object we hit has the "Turret" tag
        if (collision.gameObject.CompareTag("Turret"))
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over!");
        // Reloads the currently active scene to restart the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}