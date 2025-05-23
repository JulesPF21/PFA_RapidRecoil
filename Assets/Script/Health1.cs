using ECM2;
using ECM2.Examples.FirstPerson;
using UnityEngine;
using UnityEngine.UI;

public class Health1 : MonoBehaviour
{
    private Image HealthBarImage;
    public float CurrentHealth;
    public float health = 100f;
    PlayerControllerGym Player;
    // Start is called before the first frame update
    void Start()
    {
        HealthBarImage = GetComponent<Image>();
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerGym>();
    }
    // Méthode pour infliger des dégâts
    public void TakeDamage(float amount)
    {
        health -= amount; // Réduit la vie en fonction des dégâts
    }

// Update is called once per frame
    void Update()
    {
        CurrentHealth = Player.Health;
        HealthBarImage.fillAmount = CurrentHealth / health;
    }
}