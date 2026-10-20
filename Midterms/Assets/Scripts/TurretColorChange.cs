using UnityEngine;

public class TurretColorChange : MonoBehaviour, ISwitchable
{
    public void Interact(GameObject interactor)
    {

    }
    /*    [SerializeField] private Color clickedColor = Color.red;

        private Renderer objectRenderer;

        private void Start()
        {
            // Get and cache the Renderer component when the game starts
            objectRenderer = GetComponent<Renderer>();
        }

        private void OnMouseDown()
        {
            // Change the material color when clicked
            if (objectRenderer != null)
            {
                objectRenderer.material.color = clickedColor;
            }
        }*/
    [SerializeField] private Renderer pointerRenderer; // Drag your 3D object's MeshRenderer here
    [SerializeField] private Renderer bulletRenderer;
    [SerializeField] private Material[] materials;    // Add your list of materials in the Inspector
    private int currentIndex = 0;

    // Call this function from your UI Button OnClick event
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

    // Optional: Cycle to the next material in sequence on press
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
        // Detects the frame the key or mouse button is pressed down
        if (Input.GetMouseButtonDown(0)) // 0 = Left click
        {
            CycleNextMaterial();
        }
    }
}

