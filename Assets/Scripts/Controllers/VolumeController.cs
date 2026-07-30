using UnityEngine;

public class VolumeController : MonoBehaviour
{
    public void ApplyVolumeSettings(Manager manager, bool isEnable, GameObject volume) {
        volume.SetActive(isEnable);
    }
}