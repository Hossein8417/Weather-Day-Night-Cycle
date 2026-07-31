using System.Collections.Generic;
using UnityEngine;
public enum Types { 
    Sunny,
    Cloudy,
    Rainy,
    Snowy,
    Morning,
    Midday,
    Evening,
    Night
}
public class StatesRegistry : MonoBehaviour
{
    [SerializeField]
    private StatesSO sunnyAsset;
    [SerializeField]
    private StatesSO cloudyAsset;
    [SerializeField]
    private StatesSO rainyAsset;
    [SerializeField]
    private StatesSO snowyAsset;
    [SerializeField]
    private StatesSO morningAsset;
    [SerializeField]
    private StatesSO middayAsset;
    [SerializeField]
    private StatesSO eveningAsset;
    [SerializeField]
    private StatesSO nightAsset;

   
    public Dictionary<Types, StatesSO> assets = new Dictionary<Types, StatesSO>();

    private void Awake()
    {
        assets.Add(Types.Sunny, sunnyAsset);
        assets.Add(Types.Cloudy, cloudyAsset);
        assets.Add(Types.Rainy, rainyAsset);
        assets.Add(Types.Snowy, snowyAsset);
        assets.Add(Types.Morning, morningAsset);
        assets.Add (Types.Midday, middayAsset);
        assets.Add (Types.Evening, eveningAsset);
        assets.Add (Types.Night, nightAsset);
    }
}