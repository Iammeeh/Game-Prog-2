using System.Xml.Serialization;
using UnityEngine;

public class Week1 : MonoBehaviour
{
    public int HP;
    public BoxCollider hitbox_1;
    public BoxCollider hitbox_2;
    // GET COMPONENTS
    /*private void Awake()
    {
        //Gets the component from where the script is attached
        hitbox_1 = GetComponent<BoxCollider>();
        Debug.Log("Hello");
        HP = 1;
    }
    //ONLY RUNS WHEN OBJECT IS TRUE/ENABLE
    private void OnEnable()
    {
        Debug.Log("Hello");         
    }

    private void OnDisable()
    {
        Debug.Log("bye");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //MANIPULATE VARIABLES
    void Start()
    {
        HP = 3;
        hitbox_1.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }*/

    public Color color_cube;
    public MeshRenderer mr;

    private void Awake()
    {
        mr = GetComponent<MeshRenderer>();
    }
    //Clicking the GameObject triggers this method
    //1. Object MUST have a Collider
    private void OnMouseDown()
    {
        Debug.Log("U CLICKED ME :)");
        mr.material.color = Color.red;
    }

    private void OnMouseUp()
    {
        Debug.Log("U RELEASE ME :(");
        mr.material.color = Color.green;
    }

    private void OnMouseEnter()
    {
        mr.material.color = Color.cyan;
    }

    private void OnMouseExit()
    {
        mr.material.color = Color.magenta;
    }
}
