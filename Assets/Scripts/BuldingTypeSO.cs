using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.3.8
/// </summary>
[CreateAssetMenu(menuName = "ScriptableObjects/BuildingType")]
public class BuldingTypeSO : ScriptableObject
{
    public string nameString;
    public Transform prefabe;
    public ResourceGeneratorData resourceGeneratorData;
}
