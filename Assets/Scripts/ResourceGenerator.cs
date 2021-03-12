using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.3.11
/// </summary>

public class ResourceGenerator : MonoBehaviour
{

    [SerializeField]
    private ResourceManager resourceManager;

    private float timer;
    private float timerMax;
    private BuldingTypeSO buldingType;

    private void Awake()
    {
        buldingType = GetComponent<BuildingTypeHolder>().buldingType;
        timerMax = buldingType.resourceGeneratorData.timerMax;
       // timerMax = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            timer += timerMax;
            Debug.Log("time: add "+ buldingType.resourceGeneratorData.resourceType.nameString); //one resource every per second
            ResourceManager.Instance.AddResource(buldingType.resourceGeneratorData.resourceType,1);
        }
    }
}
