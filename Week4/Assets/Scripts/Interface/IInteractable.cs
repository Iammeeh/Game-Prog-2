using UnityEngine;

public interface IInteractable
{
    //No public or private modifier is allowed here
    //Because interface members are public by definition
    void Interact(GameObject interactor)
    {

    }
}
