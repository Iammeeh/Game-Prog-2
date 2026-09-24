using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int score;
    public TextMeshProUGUI ScoreText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    
    public void AddScore(int value)
    { 
        score += value;
    }

    public void DeductScore(int value) 
    { 
        score -= value; 
    }
    // Update is called once per frame
    void Update()
    {
        ScoreText.text = score.ToString();
    }
}
