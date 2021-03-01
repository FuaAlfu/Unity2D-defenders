using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 2021.3.1
/// </summary>
public class GameSession : MonoBehaviour
{
    /*
     all things about this game
     */
    [SerializeField]
    Text hitText;
    int hit;
    // Start is called before the first frame update
    void Start()
    {
        hitText.text = hit.ToString();
    }

    public void Hits(int hits)
    {
        hit += hits;
        hitText.text = hit.ToString();
        // playerSound.CoinPickUpSfx();
    }
}
