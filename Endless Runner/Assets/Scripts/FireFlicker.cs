using UnityEngine;

public class FireFlicker : MonoBehaviour
{
    Light fireLight;

    [Header("Intensity")]
    public float minIntensity = 1.5f;
    public float maxIntensity = 3f;

    [Header("Speed")]
    public float flickerSpeed = 15f;

    float random;

    void Start()
    {
        fireLight = GetComponent<Light>();
    }

    void Update()
    {
        random = Mathf.PerlinNoise(Time.time * flickerSpeed, 0.0f);

        fireLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, random);
    }
}