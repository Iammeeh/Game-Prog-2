using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;
public class TurretShooter : MonoBehaviour
{
    [SerializeField] private Transform firePoint;
    [SerializeField] private float ShootForce;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private bool IsSemiAutomatic = false;
    [SerializeField] private float ShootDelay = 0.5f;
    [SerializeField] private string targetTag = "Enemy";
    [SerializeField] private float rotationSpeed = 100f;
    [SerializeField] private float detectionRadius = 50f; 
    private float NextShootTime;
    private InputAction shootAction;

    private void Start()
    {
        shootAction = InputSystem.actions.FindAction("Attack");
        shootAction.started += OnAttackButtonPressed;
    }
    private void OnAttackButtonPressed(InputAction.CallbackContext _)
    {
        if(IsSemiAutomatic)
        Shoot();
    }
    private void Update()
    {
/*        if (target == null)
        {
            return;
        }*/

        if (!IsSemiAutomatic && shootAction.IsPressed())
        { 
        Shoot();
        }

        GameObject nearest = FindNearestObject();

        if (nearest != null)
        {
            Vector3 targetDirection = nearest.transform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }
        /*        Vector3 directionToTarget = (target.position - transform.position).normalized;

                if (directionToTarget != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                    // slerp = spherical linear interpolation
                    float dotProduct = Vector3.Dot(transform.position, target.position);
                }*/
    }
    private void Shoot()
    {
        if (Time.time < NextShootTime) return;
        NextShootTime = Time.time + ShootDelay;

        GameObject newBullet = Instantiate(Bullet, firePoint.position, firePoint.rotation);
        if (newBullet.TryGetComponent(out Rigidbody rb))
            rb.AddForce(ShootForce * firePoint.forward * Time.fixedDeltaTime, ForceMode.Impulse);
    }
    private void OnDestroy()
    {
        shootAction.started -= OnAttackButtonPressed;
    }
    GameObject FindNearestObject()
    {
        GameObject[] targets = GameObject.FindGameObjectsWithTag(targetTag);
        GameObject closest = null;
        float closestDistance = detectionRadius;

        foreach (GameObject target in targets)
        {
            float distance = Vector3.Distance(transform.position, target.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closest = target;
            }
        }
        return closest;
    }
}

