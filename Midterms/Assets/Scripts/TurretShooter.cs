using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.GraphicsBuffer;
public class TurretShooter : MonoBehaviour
{
    /*public GameObject Bullet;
    public GameObject FirePosition;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Shooting();
        } 
    }

    public void Shooting()
    {
        Instantiate(Bullet, FirePosition.transform.position, FirePosition.transform.rotation);
    }*/

    /*    [Header("Shooting Settings")]
        public GameObject Bullet; 
        public Transform firePoint;        
        public float fireRate = 0.5f;       
        private float nextFireTime = 0f;
        public Transform target;
        public float rotationSpeed = 5;
        void Update()
        {

            if (Time.time >= nextFireTime)
            {
                Shoot();
                nextFireTime = Time.time + fireRate; 
            }
            if (target == null)
            {
                return;
            }

            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (directionToTarget != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                // slerp = spherical linear interpolation
                float dotProduct = Vector3.Dot(transform.position, target.position);
            }
        }
        void Shoot()
        {
            if (Bullet != null && firePoint != null)
            {
                Instantiate(Bullet, firePoint.position, firePoint.rotation);
            }
        }*/

    /*public GameObject Bullet;
    public float newSpawnDuration = 0.1f;
    public float forceMultiplier = 2;
    public Transform target;
    public float rotationSpeed = 5;
    private Vector3 SpawnPos;
    private Vector3 SpawnScreenPos;

    private GameObject CurrentSpawn;
    private bool SpawnReady = false;
    private GameObject SpawnParent;

    private void Start()
    {
        SpawnPos = transform.position;
        SpawnScreenPos = Camera.main.WorldToScreenPoint(SpawnPos);
        SpawnParent = new GameObject("SpawnParent");
        SpawnNewObject();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            AutoShoot();
        }

        Vector3 directionToTarget = (target.position - transform.position).normalized;

        if (directionToTarget != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            // slerp = spherical linear interpolation
            float dotProduct = Vector3.Dot(transform.position, target.position);
        }
    }

    void AutoShoot()
    {
        if (SpawnReady)
        {
            Shoot();
        }
    }

    void SpawnNewObject()
    {
        CurrentSpawn = Instantiate(Bullet, SpawnPos, Quaternion.identity, SpawnParent.transform);
        SpawnReady = true;
    }

    void Shoot()
    {
        Vector3 Force = Input.mousePosition - SpawnScreenPos;
        CurrentSpawn.GetComponent<Rigidbody>().AddForce(new Vector3(Force.x, Force.y, Force.y) * forceMultiplier);

        SpawnReady = false;

        Invoke("SpawnNewObject", newSpawnDuration);
    }*/

    [SerializeField] private Transform firePoint;
    [SerializeField] private float ShootForce;
    [SerializeField] private GameObject Bullet;
    [SerializeField] private bool IsSemiAutomatic = false;
    [SerializeField] private float ShootDelay = 0.5f;
    /*    public Transform target;
        public float rotationSpeed = 5;*/
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
            // 1. Calculate direction vector (ignore Y if you want a flat turret-like rotation)
            Vector3 targetDirection = nearest.transform.position - transform.position;

            // 2. Create the target rotation looking at the object
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

            // 3. Smoothly rotate towards the target over time
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
        float closestDistance = detectionRadius; // Only detect within this range

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

