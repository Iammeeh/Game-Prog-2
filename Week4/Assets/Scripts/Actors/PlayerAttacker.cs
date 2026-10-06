using UnityEngine;

public class PlayerAttacker : MonoBehaviour
{
    public float attackPower = 25;

    // Update is called once per frame
    private void Update()
    {
    //0 = LMB
    //1 = RMB
    //2 = MMB
    //If clicked on enemies they will get damaged
    //Left Click triggers Raycast attack from camera
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hitInfo, 100f))
            {
                //We search exclusively for the enemy with Actor Derivation
                Actor targetActor = hitInfo.collider.GetComponent<Actor>();
                if (targetActor != null)
                {
                    Debug.Log($"Succesfully attack an Actor) {targetActor.name}");

                    //Polymorphism in action: Unity automatically calls the child override
                    targetActor.TakeDamage(attackPower);
                    targetActor.PerformAttack();
                }
            }
        }
    }
}
