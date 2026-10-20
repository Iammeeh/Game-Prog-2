using UnityEngine;

public class BulletScript : MonoBehaviour
{
    /*    public float speed = 5f;
        public Rigidbody rb;

        void Start()
        {
            rb.AddForce(transform.forward * 2000);

        }
        private void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == "Cylinder")
            {
                Destroy(this.gameObject);
            }
        }*/
    private void Start()
    {
        Invoke(nameof(Impact), 2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pointer") || other.CompareTag("Bullet"))
            return;

        if (other.TryGetComponent(out GreenEnemy greenTarget))
        {
            greenTarget.TakeDamage(20);
        }
        else if (other.TryGetComponent(out BlueEnemy blueTarget))
        {
            blueTarget.TakeDamage(20);
        }
        else if (other.TryGetComponent(out PinkEnemy pinkTarget))
        {
            pinkTarget.TakeDamage(20);
        }
        Impact();
    }

    private void Impact()
    {
        Destroy(gameObject);
    }
} 
