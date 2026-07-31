using UnityEngine;
public class ParticleController : MonoBehaviour
{
    public void ApplyParticleSettings(ParticleSystem particle, bool isEnable) {
        particle.gameObject.SetActive(isEnable);
        if (isEnable) particle.Play();
        else particle.Stop();
    }
}