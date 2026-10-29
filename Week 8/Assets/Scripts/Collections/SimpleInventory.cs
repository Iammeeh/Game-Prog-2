using UnityEngine; 
using System.Collections.Generic;
using TMPro;

public class SimpleInventory : MonoBehaviour
{
    //1. GENERIC LIST (Declarable)
    private List<string> playerItems = new List<string>();
    public TextMeshProUGUI inventoryText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //2. CREATE (Adding Items)
/*        playerItems.Add("The Throngler");
        playerItems.Add("Rejuvenating Flask");*/
    }
    public void AddItem(string itemName)
    {
        playerItems.Add(itemName);
        UpdateUI();
    }

    public void RemoveItem(string itemName)
    {
        //3. REMOVE
        if (playerItems.Remove(itemName))
        {
            /*Debug.Log("Cast away thy mortal possessions");*/
            Debug.Log($"Remove {itemName} from thy pockets");
        }
        else
        {
            Debug.LogWarning("I could not find what earthly article you are searching for");
        }
        UpdateUI();
    }
    //Drop items when player dies
    public void RemoveItemDrops()
    {
        //Loop Backwards from end to 0
        for (int i = playerItems.Count -1; i >= 0; i--)
        {
            if (playerItems[i].Contains("Flask"))
            {
                playerItems.RemoveAt(i);
            }
        }
        UpdateUI();
    }
    // Update is called once per frame
    private void UpdateUI()
    {
        //UPDATE
        inventoryText.text = "Inventory Contents: \n";
        for (int i = 0; i < playerItems.Count; i++)
        {
            inventoryText.text += $"- {playerItems[i]}\n";
        }
    }
}