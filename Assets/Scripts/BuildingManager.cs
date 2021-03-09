using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.3.4
/// </summary>

public class BuildingManager : MonoBehaviour
{
    // [SerializeField]
    // private Transform mouseVisualTransform; //for testing

    //[SerializeField]
    //private Transform pfWoodHarveser;
    //[SerializeField]
    //private BuldingTypeSO buldingType; //we could use list told multiable types  private <BuldingTypeSO> buldingType;
    //---------------------------------------------------------------------------------------------------------------
    private BuldingTypeSO buldingType;
    private BuildingTypeListSO buildingTypeList;

    //catch
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        //  Debug.LogError("err comes from your big..");
        mainCamera = Camera.main;

        //looking for a folder name
        // Debug.Log(Resources.Load<BuildingTypeListSO>("BuildingTypeList")); //add debug for testing
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name); //another way to write it :: must mach with the name of file
        buldingType = buildingTypeList.list[0];
    }

    // Update is called once per frame
    private void Update()
    {
        // Debug.Log(Input.mousePosition);
        // Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
       // mouseVisualTransform.position = GetMouseWorldPos(); //for testing
       if(Input.GetMouseButtonDown(0)) //0:left, 1:right, 2:meddile
        {
            Instantiate(buldingType.prefabe, GetMouseWorldPos(),Quaternion.identity);
        }
       //for testing

       if(Input.GetKeyDown(KeyCode.T))
        {
            buldingType = buildingTypeList.list[0];
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            buldingType = buildingTypeList.list[1];
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;

      //  Debug.Log(mouseWorldPosition); //for testing
        return mouseWorldPosition;
    }
}
