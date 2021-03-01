using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.3.1
/// </summary>

public class Test : MonoBehaviour
{
    /*
     Testing...
    ---------------------------------
     */

    private float speed = 2f, highSpeed = 6f;
    int hit = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * Random.Range(speed,highSpeed) * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if(c.gameObject.CompareTag("wall"))
        {
            FindObjectOfType<GameSession>().Hits(hit);
            Destroy(this.gameObject);
        }
    }
}
