using System;
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10;
    public float amplitude = 0.5f;      // Hauteur de l'oscillation
    public float frequency = 1f;        // Vitesse de l'oscillation

    private Vector3 startPos;
    [SerializeField] private Image objet;
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            objet.gameObject.SetActive(true);
            Destroy(this.gameObject);
        }

    }

    private void Start()
    {
        startPos = transform.position;
    }

    private void Update()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = startPos + new Vector3(0, yOffset, 0);

    }
}
