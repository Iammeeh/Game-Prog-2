using UnityEngine;

public class Grunt : Actor
{
    protected override void Awake()
    {
        base.Awake();
        maxHealth = 40f;
        currentHealth = maxHealth;
        moveSpeed = 4f;
    }
    public override void PerformAttack()
    {
        Debug.Log("BASH ATTACK!");
    }
}
