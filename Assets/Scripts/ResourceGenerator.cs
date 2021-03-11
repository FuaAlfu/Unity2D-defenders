using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.3.11
/// </summary>

public class ResourceGenerator : MonoBehaviour
{
    private float timer;
    private float timerMax;

    private void Awake()
    {
        timerMax = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            timer += timerMax;
            Debug.Log("time: add"); //one resource every per second
        }
    }
}
