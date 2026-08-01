using System.Collections.Generic;
using UnityEngine;
public enum TimeTypes { 
    Morning,
    Midday,
    Evening,
    Night
}
public class StatesRegistry : MonoBehaviour
{

    [SerializeField]
    private StatesSO morningAsset;
    [SerializeField]
    private StatesSO middayAsset;
    [SerializeField]
    private StatesSO eveningAsset;
    [SerializeField]
    private StatesSO nightAsset;

   
    private Dictionary<TimeTypes, StatesSO> assets = new Dictionary<TimeTypes, StatesSO>();

    private void Awake()
    {
        assets.Add(TimeTypes.Morning, morningAsset);
        assets.Add (TimeTypes.Midday, middayAsset);
        assets.Add (TimeTypes.Evening, eveningAsset);
        assets.Add (TimeTypes.Night, nightAsset);
    }

    public StatesSO Get(TimeTypes type) { 
        return assets[type];
    }
}