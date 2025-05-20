using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPos;
    private bool isShaking = false;

    public float shakeDuration = 0.2f;
    public float shakeMagnitude = 0.1f;

    private void Start()
    {
        originalPos = transform.localPosition;
    }

    public void TriggerShake()
    {
        if (!isShaking)
            StartCoroutine(Shake());
    }

    private IEnumerator Shake()
    {
        isShaking = true;
        float elapsed = 0f;

        while (elapsed < shakeDuration)
        {
            Vector3 randomPoint = originalPos + Random.insideUnitSphere * shakeMagnitude;
            transform.localPosition = new Vector3(randomPoint.x, randomPoint.y, originalPos.z);

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = originalPos;
        isShaking = false;
    }
}