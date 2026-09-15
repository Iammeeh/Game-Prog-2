using UnityEngine;

public class MoveTowards : MonoBehaviour
{
    public Transform target;
    public float speed = 5;
    public float rotationSpeed = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Movement
        transform.position = Vector3.MoveTowards(transform.position,target.position, speed = Time.deltaTime);
        // Rotation using Quaternions
        Vector3 directionToTarget = (target.position - transform.position).normalized;
        if (directionToTarget != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);
            transform.rotation = Quaternion.Slerp(transform.rotation,targetRotation,rotationSpeed * Time.deltaTime);
            // slerp = spherical linear interpolation
        }
        float dotProduct = Vector3.Dot(transform.position,target.position);

        if (dotProduct > 0.95)
        {
            Debug.Log("TargetLocked");
        }
        else
        {
            Debug.Log("Searching");
        }
    }
}
