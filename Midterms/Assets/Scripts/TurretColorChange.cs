using UnityEngine;

public class TurretColorChange : MonoBehaviour, ISwitchable
{
    public void SwitchMaterial(int materialIndex)
    {
        if (pointerRenderer != null && materialIndex >= 0 && materialIndex < materials.Length)
        {
            pointerRenderer.material = materials[materialIndex];
            currentIndex = materialIndex;
        }
        if (bulletRenderer != null && materialIndex >= 0 && materialIndex < materials.Length)
        {
            bulletRenderer.material = materials[materialIndex];
            currentIndex = materialIndex;
        }
    }
    [SerializeField] public Renderer pointerRenderer;
    [SerializeField] public Renderer bulletRenderer;
    [SerializeField] public Material[] materials; 
    private int currentIndex = 0;

/*    public void SwitchMaterial(int materialIndex)
    {
        if (pointerRenderer != null && materialIndex >= 0 && materialIndex < materials.Length)
        {
            pointerRenderer.material = materials[materialIndex];
            currentIndex = materialIndex;
        }
        if (bulletRenderer != null && materialIndex >= 0 && materialIndex < materials.Length)
        {
            bulletRenderer.material = materials[materialIndex];
            currentIndex = materialIndex;
        }
    }*/
    public void CycleNextMaterial()
    {
        if (materials.Length == 0 || pointerRenderer == null) return;
        currentIndex = (currentIndex + 1) % materials.Length;
        pointerRenderer.material = materials[currentIndex];

        if (materials.Length == 0 || bulletRenderer == null) return;
        currentIndex = (currentIndex + 0) % materials.Length;
        bulletRenderer.material = materials[currentIndex];
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            CycleNextMaterial();
        }
    }
}

