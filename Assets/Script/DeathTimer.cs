using UnityEngine;
using TMPro;

public class DeathTimer : MonoBehaviour
{
    public float timeLimit = 30f; 
    private float timer;
    private bool isDead = false;

    public TextMeshProUGUI timerText;
    void Start()
    {
        timer = timeLimit;
    }

    void Update()
    {
        if (isDead) return;

        timer -= Time.deltaTime;

        UpdateUI();
        
        if (timer <= 0f)
        {
            Die();
        }
    }
    
    void UpdateUI()
    {
        float minutes = Mathf.FloorToInt(timer / 60f);
        float seconds = Mathf.FloorToInt(timer % 60f);
        timerText.text = $"{minutes:00}:{seconds:00}";
    }

    void Die()
    {
        isDead = true;
        timerText.text = "00:00";
        FindObjectOfType<DeathManager>().ShowDeathScreen();
    }
    
    public void ResetTimer()
    {
        timer = timeLimit;
        isDead = false;
    }
}