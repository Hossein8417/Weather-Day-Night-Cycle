using UnityEngine;

public class WeatherData : MonoBehaviour
{
    [Header("Light & Sun")]
    public Light sun;
    public Light light;

    [Header("Volumes")]
    public GameObject sunnyVolume;
    public GameObject cloudyVolume;
    public GameObject rainyVolume;
    public GameObject snowyVolume;

    [Header("ParticleSystems")]
    public ParticleSystem rainyParticle;
    public ParticleSystem snowyParticle;
}