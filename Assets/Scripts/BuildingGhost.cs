using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.5.1
/// </summary>

public class BuildingGhost : MonoBehaviour
{
    private GameObject spriteGameObject;

    private void Awake()
    {
        spriteGameObject = transform.Find("Sprite").gameObject;
        Hide();
    }

    private void Start()
    {
        //subs to an event
        BuildingManager.Instance.OnActiveBuildingTypeChanged += BuildingManager_OnActiveBuildingTypeChanged;
    }

    private void BuildingManager_OnActiveBuildingTypeChanged(object sender, BuildingManager.OnActiveBuildingTypeChangedEventArgs e)
    {
        //BuldingTypeSO buildingTypeSO = BuildingManager.Instance.GetActiveBuildingType(); //old but gold
        //todo..
        if(e.activeBuldingType == null)
        {
            Hide();
        }
        else
        {
            Show(e.activeBuldingType.sprite);
        }
    }

    private void Update()
    {
        transform.position = UtilsClass.GetMouseWorldPos();
    }

    private void Show(Sprite ghostSprite)
    {
        spriteGameObject.SetActive(true);
        spriteGameObject.GetComponent<SpriteRenderer>().sprite = ghostSprite;
    }

    private void Hide()
    {
        spriteGameObject.SetActive(false);
    }
}
