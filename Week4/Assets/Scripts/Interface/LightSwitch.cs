using UnityEngine;

public class LightSwitch : MonoBehaviour, IInteractable
{
    public Light lightSource;
    public bool isLightOn = true;
    public void Interact(GameObject interactor)
    {
        isLightOn = !isLightOn;
        if (lightSource != null)
        {
            lightSource.enabled = isLightOn;
        }
    }
}