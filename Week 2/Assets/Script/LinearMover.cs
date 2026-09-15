using UnityEngine;

public class LinearMover : MonoBehaviour
{
    public Transform target;
    public float speed = 5f;

    private void Awake()
    {

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Find the vector pointing to the target (destination - origin)
        Vector3 directionToTarget = target.position - transform.position;

        // Check distance so we dont vibrate around the  target
        if (directionToTarget.magnitude > 0.1f)
        {
            // Normalize the direction and apply the movement
            Vector3 normalizedDirection = directionToTarget.normalized;
            transform.position += normalizedDirection * speed * Time.deltaTime;
            // Ensures the movement is smooth regardless of the computers frame rate
        }
    }

    private void FixedUpdate()
    {
        
    }
    private void LateUpdate()
    {
        
    }
}
