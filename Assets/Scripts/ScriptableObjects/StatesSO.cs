using UnityEngine;
[CreateAssetMenu(fileName = "StatesSO", menuName = "Data/States")]
public class StatesSO : ScriptableObject
{
    public Vector3 stateRotation;
    public Vector3 defaultRotation;
    public float sunLuxAmount;
    public float sunColorTemperature;
    public float lightLuxAmount;
    public float lightColorTemperature;
}