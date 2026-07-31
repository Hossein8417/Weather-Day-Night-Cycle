using UnityEngine;
public class MaterialController : MonoBehaviour
{
    public void ApplyMaterialSettings(Manager manager, Material material) {
        manager.data.ground.GetComponent<Renderer>().material = material;
    } 
}