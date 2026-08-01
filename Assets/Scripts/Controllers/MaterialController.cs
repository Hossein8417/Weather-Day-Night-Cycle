using UnityEngine;
public class MaterialController : MonoBehaviour
{
    public void ApplyMaterialSettings(GameObject ground, Material material) {
        ground.GetComponent<Renderer>().material = material;
    } 
}