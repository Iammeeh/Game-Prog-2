public class BlueEnemy : EnemyBase
{
    protected override void Awake()
    {
        base.Awake();
        maxHealth = 10f;
        currentHealth = maxHealth;
    }
}