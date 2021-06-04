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
    private ResourceGeneratorData resourceGeneratorData;
    private float timer;
    private float timerMax;
   // private BuldingTypeSO buldingType;

    private void Awake()
    {
        //buldingType = GetComponent<BuildingTypeHolder>().buldingType;
        //timerMax = buldingType.resourceGeneratorData.timerMax;
        resourceGeneratorData = GetComponent<BuildingTypeHolder>().buldingType.resourceGeneratorData;
        timerMax = resourceGeneratorData.timerMax;
        // timerMax = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        //ollider2D[] collider2DArray = Physics2D.OverlapCircleAll(transform.position, 5f);
        Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(transform.position, resourceGeneratorData.resourceDetectionRadius);

        int nearbyResourceAmount = 0;
        foreach(Collider2D collider2D in collider2DArray)
        {
           ResourceNode resourceNode = collider2D.GetComponent<ResourceNode>();
            if(resourceNode != null)
            {
                //todo   :: it's a resource node
                nearbyResourceAmount++;
            }
        }
        //clamb our values
        nearbyResourceAmount = Mathf.Clamp(nearbyResourceAmount, 0, resourceGeneratorData.maxResourceAmount);
        if(nearbyResourceAmount == 0)
        {
            //no resource nodes nearby :: disable the script (disable resource generator)
            enabled = false;
        }
        print("nearbyResourceAmount: " + nearbyResourceAmount);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            timer += timerMax;
            Debug.Log("time: add "+ resourceGeneratorData.resourceType.nameString); //one resource every per second :: buldingType.resourceGeneratorData.resourceType.nameString);
            ResourceManager.Instance.AddResource(resourceGeneratorData.resourceType,1);  //ResourceManager.Instance.AddResource(buldingType.resourceGeneratorData.resourceType,1);
        }
    }
}
