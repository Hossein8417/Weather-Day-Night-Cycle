using UnityEngine;
public class VolumeController : MonoBehaviour
{
    public void ApplyVolumeSettings(bool isEnable, GameObject volume) {
        volume.SetActive(isEnable);
    }
}