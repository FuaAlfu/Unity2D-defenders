using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructableTiles : MonoBehaviour
{
    /*
    TODO\

    */

    public
    Tilemap destructableWall;


    // Start is called before the first frame update
    void Start()
    {
        destructableWall = GetComponent<Tilemap>();
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("bomb"))
        {
            Vector3 hitPosition = Vector3.zero;
            foreach (ContactPoint2D hit in c.contacts)
            {
                //0.01f outside of object
                hitPosition.x = hit.point.x - 0.01f * hit.normal.x;
                hitPosition.y = hit.point.y - 0.01f * hit.normal.y;
                destructableWall.SetTile(destructableWall.WorldToCell(hitPosition), null);
                Debug.LogError("hitttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttttt");
            }
        }
    }
}
