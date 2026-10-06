using UnityEngine;
//ABSTRACT - prevents anyone from accidentally
//attaching this script to any game object
public abstract class Actor : MonoBehaviour
{
    //Protected instead of private, this keeps maxhealth hidden from
    //unrelated outside script
    //While allowing child classes to read and adjust this
    [Header("Base Actor Attributes")]
    [SerializeField] protected float maxHealth = 100f;
    protected float currentHealth;
    [SerializeField] protected float moveSpeed = 3f;

    //We mark awake as virtual:
    //Ensures child classes can initialize their own variable in their own awake
    protected virtual void Awake()
    {
        currentHealth = maxHealth;
    }

    //Every enemy attacks differently, we declare this method as abstract
    public abstract void PerformAttack();

    //Unlike attack we mark it as virtual so child classes
    //can use standard health subtraction formula
    public virtual void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log($"{gameObject.name} took {damageAmount}");

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
