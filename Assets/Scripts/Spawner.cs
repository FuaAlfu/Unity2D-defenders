using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 2021.3.1
/// </summary>
public class Spawner : MonoBehaviour
{
    /*
     for testing
     */
    // Start is called before the first frame update

    [Tooltip("spawn timer")]
    [SerializeField]
    private float min, max;

    [SerializeField]
    GameObject p;

    [SerializeField]
    Transform port;
    void Start()
    {
        StartCoroutine(Spawinig());
    }

    IEnumerator Spawinig()
    {
        while (true) //infinite loop
        {
            yield return new WaitForSeconds(Random.Range(min, max));
            Spawn();
        }
        yield break;
    }

    void Spawn()
    {
        GameObject g = Instantiate(p, port.position, Quaternion.identity) as GameObject;
        g.transform.parent = transform;
    }
}
