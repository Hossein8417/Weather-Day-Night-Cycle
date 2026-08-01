using UnityEngine;
public class Data : MonoBehaviour
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

    [Header("Materials")]
    public Material snowMaterial;
    public Material defaultMaterial;

    [Header("Objects")]
    public GameObject ground;

}