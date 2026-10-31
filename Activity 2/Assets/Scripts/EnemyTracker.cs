using UnityEngine;
using System.Collections.Generic;
using TMPro;

public class EnemyTracker : MonoBehaviour
{
    private List<string> activeEnemies = new List<string>();
    public TextMeshProUGUI enemyCount;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SpawnEnemy(string enemyName)
    {
        activeEnemies.Add(enemyName);
        UpdateUI();
    }

    public void DefeatEnemy(string enemyName)
    {
        //3. REMOVE
        if (activeEnemies.Remove(enemyName))
        {
            /*Debug.Log("Cast away thy mortal possessions");*/
            Debug.Log($"Send {enemyName} to the shadow realm");
        }
        else
        {
            Debug.LogWarning("Wherefore art thou the opps");
        }
        UpdateUI();
    }

    public void Wipeout()
    {
        //Loop Backwards from end to 0
        for (int i = activeEnemies.Count - 1; i >= 0; i--)
        {
            if (activeEnemies[i].Contains("Enemy"))
            {
                activeEnemies.RemoveAt(i);
            }
        }
        UpdateUI();
    }

    private void UpdateUI()
    {
        //UPDATE
        enemyCount.text = "Enemies in Wave: \n";
        for (int i = 0; i < activeEnemies.Count; i++)
        {
            enemyCount.text += $"- {activeEnemies[i]}\n";
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
