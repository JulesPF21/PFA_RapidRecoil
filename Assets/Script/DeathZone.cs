using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<DeathManager>().ShowDeathScreen();
        }

    }
}
