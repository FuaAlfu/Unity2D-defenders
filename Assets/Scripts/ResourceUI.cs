using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 2021.3.14
/// </summary>

public class ResourceUI : MonoBehaviour
{
    //[SerializeField]
    //private Transform resourceTemplate;

    private void Awake()
    {
        ResourceTypeListSO resourceTypeList = Resources.Load<ResourceTypeListSO>(typeof(ResourceTypeListSO).Name);

        Transform resourceTemplate = transform.Find("resourceTemplate");
        resourceTemplate.gameObject.SetActive(false); //to make sure that our temp is hidden

        int index = 0;
        foreach(ResourceTypeSO resourceType in resourceTypeList.list)
        {
            Transform resourceTransform = Instantiate(resourceTemplate, transform);
            resourceTransform.gameObject.SetActive(true);

            float offsetAmount = -160f;
            resourceTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index,0); //x & y

            resourceTransform.Find("image").GetComponent<Image>().sprite = resourceType.sprite;

           // int resourceAmount = ResourceManager.InstanceGetResourceAmount();
           // resourceTransform.Find("text").GetComponent<TextMeshProUGUI>().SetText();
            index++;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
