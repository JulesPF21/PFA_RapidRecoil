using UnityEngine;

public class SkyManager : MonoBehaviour
{
    [SerializeField] private float rotationSpeed;
    void Update()
    {
        RenderSettings.skybox.SetFloat("_RotationSpeed", Time.time * rotationSpeed);
    }
}
