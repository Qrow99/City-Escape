using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public Transform player;
    // Use this for initialization
    void Start()
    {
        if (Level_Loader.prevScene == "Medkit puzzle")
        {
            player.position = new Vector2(6f, 1.0f);
        }
    }

}
