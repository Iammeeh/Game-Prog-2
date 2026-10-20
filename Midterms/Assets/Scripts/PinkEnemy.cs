public class PinkEnemy : EnemyBase
{
    protected override void Awake()
    {
        base.Awake();
        maxHealth = 10f;
        currentHealth = maxHealth;
    }
}