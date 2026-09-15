using UnityEngine;

public class LerpMover : MonoBehaviour
{
    public Transform target;
    public float timeToReachTarget = 2;

    Vector3 startPosition;
    float fractionOfJourney = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Record exactly where we started 
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && fractionOfJourney < 1f)
        {
            // Accumulate the percentage of time passed
            fractionOfJourney += Time.deltaTime/timeToReachTarget;

            // Teleport to exact percentage point between start and target
            transform.position = Vector3.Lerp(startPosition, target.position, fractionOfJourney);
        }
    }
}
