using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.3.10
/// </summary>

public class ResourceManager : MonoBehaviour
{
    //singleton
    public static ResourceManager Instance { get; private set; } //using props ..ptv set: nean modifi only here in this type

    /*
     TODO\
    ----------------------------
    another way to type an instance :: old
     private static ResourceManager instance;
    public static ResourceManager GetInstance()
    {
        return instance;
    }
    private static void SetInstance(ResourceManager set)
    {
        instance = set;
    }
     */

    //create a map :: k -> v
    private Dictionary<ResourceTypeSO, int> resourceAmountDictionary;

    private void Awake()
    {
        Instance = this;

        resourceAmountDictionary = new Dictionary<ResourceTypeSO, int>();
        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

        foreach(ResourceTypeSO resourceType in resourceTypeList.list)
        {
            resourceAmountDictionary[resourceType] = 0;
            
        }
        TestLogResourceAmountDictionary();
    }

    //for testing
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);
            AddResource(resourceTypeList.list[0], 2);
            TestLogResourceAmountDictionary();
        }
    }

    private void TestLogResourceAmountDictionary()
    {
        foreach(ResourceTypeSO resourceType in resourceAmountDictionary.Keys)
        {
            Debug.Log(resourceType.nameString + ": " + resourceAmountDictionary[resourceType]);
        }
    }

    public void AddResource(ResourceTypeSO resourceType, int amount)
    {
        resourceAmountDictionary[resourceType] += amount;
        TestLogResourceAmountDictionary();
    }
}
