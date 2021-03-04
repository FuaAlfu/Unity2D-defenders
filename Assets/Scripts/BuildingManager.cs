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

    [SerializeField]
    private Transform pfWoodHarveser;

    //catch
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        //  Debug.LogError("err comes from your big..");
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    private void Update()
    {
        // Debug.Log(Input.mousePosition);
        // Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
       // mouseVisualTransform.position = GetMouseWorldPos(); //for testing
       if(Input.GetMouseButtonDown(0)) //0:left, 1:right, 2:meddile
        {
            Instantiate(pfWoodHarveser,GetMouseWorldPos(),Quaternion.identity);
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
