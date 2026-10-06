using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    // The movement speed of the character
    public float speed = 5.0f;

    public float interactRange = 3f;

    void Update()
    {
        // Get horizontal and vertical inputs (WASD / Arrow Keys)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Create a movement vector based on inputs
        Vector3 movement = new Vector3(moveX, 0.0f, moveZ);

        // Move the GameObject over time
        transform.Translate(movement * speed * Time.deltaTime, Space.World);
        InteractsObjects();
    }

    void InteractsObjects()
    {
        Ray ray = new Ray(transform.position,transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, interactRange))
        {
            IInteractable interactableObj = hitInfo.collider.GetComponent<IInteractable>();
            if (interactableObj != null)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    interactableObj.Interact(gameObject);
                }
            }
        }
    }
}