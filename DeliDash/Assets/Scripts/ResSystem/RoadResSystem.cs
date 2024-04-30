using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JKFrame;

public class RoadResSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        ResSystem.InitGameObjectPoolForAssetName("Car",30,10);
        ResSystem.InitGameObjectPoolForAssetName("TrafficPolice",5,3);
    }

    // Update is called once per frame
    void Update()
    {
        //ResSystem.InstantiateGameObject<>("Car",transform);
    }
}
