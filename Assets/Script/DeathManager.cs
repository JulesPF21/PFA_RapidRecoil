using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathManager : MonoBehaviour
{

    private bool isDead = false;

    public void ShowDeathScreen()
    {
        if (isDead) return;
        
        isDead = true;
        SceneManager.LoadScene(2); 

        // Stop time if you want
        Time.timeScale = 0f;

        // Optionnel : désactiver le contrôleur
        var controller = FindObjectOfType<PlayerController>();
        if (controller) controller.enabled = false;
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1); 
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0); 
    }
}