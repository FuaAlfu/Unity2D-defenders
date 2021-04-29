using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
    //private BuldingTypeSO activeBuldingType; //we could use list told multiable types  private <BuldingTypeSO> activeBuldingType;
    //---------------------------------------------------------------------------------------------------------------
    public static BuildingManager Instance { get; private set; }
    private BuldingTypeSO activeBuldingType;
    private BuildingTypeListSO buildingTypeList;

    //catch
    private Camera mainCamera;

    private void Awake()
    {
        //looking for a folder name
        // Debug.Log(Resources.Load<BuildingTypeListSO>("BuildingTypeList")); //add debug for testing
        Instance = this;
        buildingTypeList = Resources.Load<BuildingTypeListSO>(typeof(BuildingTypeListSO).Name); //another way to write it :: must mach with the name of file
        //activeBuldingType = buildingTypeList.list[0];

    }

    // Start is called before the first frame update
    void Start()
    {
        //here we using instance of camera inside start not inside awake becuase its an external object.
        //  Debug.LogError("err comes from your big..");
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        // Debug.Log(Input.mousePosition);
        // Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
       // mouseVisualTransform.position = GetMouseWorldPos(); //for testing
       if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) //0:left, 1:right, 2:meddile
        {
            if (activeBuldingType != null)
            {
                Instantiate(activeBuldingType.prefabe, GetMouseWorldPos(), Quaternion.identity);
            }
        }
        //for testing

        //if (Input.GetKeyDown(KeyCode.T))
        //{
        //    activeBuldingType = buildingTypeList.list[0];
        //}
        //if (Input.GetKeyDown(KeyCode.Y))
        //{
        //    activeBuldingType = buildingTypeList.list[1];
        //}
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;

      //  Debug.Log(mouseWorldPosition); //for testing
        return mouseWorldPosition;
    }

    public void SetActiveBuildingType(BuldingTypeSO buldingType)
    {
        activeBuldingType = buldingType;
    }

    public BuldingTypeSO GetActiveBuildingType()
    {
        return activeBuldingType;
    }
}
