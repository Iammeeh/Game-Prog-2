using UnityEngine;

public class Grunt : Actor
{
    protected override void Awake()
    {
        base.Awake();
        maxHealth = 100f;
        currentHealth = maxHealth;
        moveSpeed = 4f;
    }
    public override void PerformAttack()
    {
        Debug.Log("BASH ATTACK!");
    }
}
