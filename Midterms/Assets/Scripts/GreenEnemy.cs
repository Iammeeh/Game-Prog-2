using UnityEngine;

public class GreenEnemy : EnemyBase
{
    protected override void Awake()
    {
        base.Awake();
        maxHealth = 10f;
        currentHealth = maxHealth;
        moveSpeed = 3f;
    }
}
