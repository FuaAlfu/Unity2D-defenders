using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.5.1
/// </summary>

public static class UtilsClass
{
    private static Camera mainCamera;
    public static Vector3 GetMouseWorldPos()
    {
        if (mainCamera == null) mainCamera = Camera.main;
        Vector3 mouseWorldPosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0f;

        //  Debug.Log(mouseWorldPosition); //for testing
        return mouseWorldPosition;
    }
}
