using UnityEngine;

public class TurretTracker : MonoBehaviour
{
    public Transform target;
    public float rotationSpeed = 5;

    // Update is called once per frame
    void Update()
    {
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
}
