using UnityEngine;

public class Exploder : Actor
{
    public float explosionRadius = 5f;
    public override void PerformAttack()
    {
        Explode();
    }
    public override void TakeDamage(float damageAmount)
    {
        Explode();
    }
    private void Explode()
    {
        Debug.Log("*cue slow mo explosion BOOM BOOM BOOM");
        Destroy(gameObject);
    }
}
