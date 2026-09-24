using System;
using UnityEngine;

public class OrbitalTarget : MonoBehaviour
{
    public Transform pointA, pointB;
    public float travelDuration;
    public SphereCollider hitbox_1;
    private float timer;
    private Boolean isMovingToB = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //1. Add frame time to stopwatch
        timer += Time.deltaTime;
        float t = timer / travelDuration;

        //2. 
        /*        Vector3 start, target;

                if (isMovingToB)
                {
                    start = pointA.position;
                    target = pointB.position;

                }
                else
                {
                    start = pointB.position;
                    target = pointA.position;
                }
        */
        Vector3 start = isMovingToB ? pointA.position : pointB.position;
        Vector3 target = isMovingToB ? pointB.position : pointA.position;

        //Apply Movement
        transform.position = Vector3.Lerp(start, target, t);

        //4. If Arrived at target, reset timer and switch direction
        if (t > 1f)
        {
            timer = 0f;
            isMovingToB = !isMovingToB;
        }
    }

    /*private void OnMouseDown()
    {
        Debug.Log("Add 25 Points");
        GameManager.Instance.AddScore(25);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "HazardZone")
        {
            Debug.Log("HAZARD!");
        }
        GameManager.Instance.DeductScore(25);
    }*/
}
