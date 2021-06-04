using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.3.11
/// </summary>

[System.Serializable]
public class ResourceGeneratorData
{
    //a simple datasructure
    public float timerMax;
    public ResourceTypeSO resourceType;
    public float resourceDetectionRadius;
    public int maxResourceAmount;


    /*storing data  and [System.Serializable]
     When you create an object in a .Net framework application, you don't need to think about how the data is stored in memory.
    Because the .Net Framework takes care of that for you. However, if you want to store the contents of an object to a file,
    send an object to another process or transmit it across the network,
    you do have to think about how the object is represented because you will need to convert to a different format.
    This conversion is called SERIALIZATION.
     */
}
