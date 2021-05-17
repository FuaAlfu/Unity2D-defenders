using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.5.16
/// </summary>

public class SpritePositionSortingOrder : MonoBehaviour
{
    [SerializeField] private bool runOnce;
    [SerializeField] private float positionOffsetY;

    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        float precisionMultiplier = 5f;
       spriteRenderer.sortingOrder = (int)(-(transform.position.y + positionOffsetY) * precisionMultiplier);

        if(runOnce)
        {
            Destroy(this); //the script, not the game object
        }
    }
}
