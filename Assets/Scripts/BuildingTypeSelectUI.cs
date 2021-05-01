using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 2021.4.3
/// </summary>

public class BuildingTypeSelectUI : MonoBehaviour
{
    [SerializeField] private Sprite arrowSprite;
    //for selected btn
    private Dictionary<BuldingTypeSO, Transform> btnTransformDictionary;
    private Transform arrowBtn;
    private void Awake()
    {
       Transform btnTemplate = transform.Find("btnTemplate");
        btnTemplate.gameObject.SetActive(false);

        BuildingTypeListSO buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name);

        btnTransformDictionary = new Dictionary<BuldingTypeSO, Transform>();
        int index = 0;

        //--   [mouse cursor]
        //Transform arrowBtn = Instantiate(btnTemplate, transform);
        //arrowBtn.gameObject.SetActive(true);

        //float offsetAmount = +130f; //going right
        //arrowBtn.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0); //x & y
        //arrowBtn.Find("image").GetComponent<Image>().sprite = arrowSprite;
        //arrowBtn.GetComponent<Button>().onClick.AddListener(() => {
        //    BuildingManager.Instance.SetActiveBuildingType(null);
        //});

        //index++;

        //--
        foreach (BuldingTypeSO buildingType in buildingTypeList.list)
        {
           Transform btnTransform = Instantiate(btnTemplate, transform);
            btnTransform.gameObject.SetActive(true);

            float offsetAmount = +130f; //going right :: remove float
            btnTransform.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetAmount * index, 0); //x & y
            btnTransform.Find("image").GetComponent<Image>().sprite = buildingType.sprite;
            btnTransform.GetComponent<Button>().onClick.AddListener(() => {
                BuildingManager.Instance.SetActiveBuildingType(buildingType);
            });

            btnTransformDictionary[buildingType] = btnTransform;
            index++;
        }
    }

    private void Update()
    {
        UpdateActiveBuildingTypeButton();
    }
    private void UpdateActiveBuildingTypeButton()
    {
        //arrowBtn.Find("selected").gameObject.SetActive(false);
        foreach (BuldingTypeSO buldingType in btnTransformDictionary.Keys)
        {
            Transform btnTransform = btnTransformDictionary[buldingType];
            btnTransform.Find("selected").gameObject.SetActive(false);
        }
       BuldingTypeSO activeBuildingType = BuildingManager.Instance.GetActiveBuildingType();
        if (activeBuildingType == null)
        {
            arrowBtn.Find("selected").gameObject.SetActive(true);
        }
        else
        {
            btnTransformDictionary[activeBuildingType].Find("selected").gameObject.SetActive(true);
        }
    }
}
