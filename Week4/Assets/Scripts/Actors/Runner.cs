using UnityEngine;

public class Runner : Actor
{
    protected override void Awake()
    {
        base.Awake();
        maxHealth = 20f;
        currentHealth = maxHealth;
        moveSpeed = 15f;
    }
    public override void PerformAttack()
    {
        Debug.Log("Gotta go FAST");
    }
}

