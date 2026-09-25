using UnityEngine;

public class InteractiveItem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int maxClicks = 10;
    public int currentClicks = 0;
    private void OnMouseDown()
    {
        currentClicks++;
        GameManager.Instance.AddScore(25);
        if (currentClicks == maxClicks)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "HazardZone")
        {
            Debug.Log("HAZARD!");
        }
        GameManager.Instance.DeductScore(25);
    }
}
