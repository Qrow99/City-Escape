using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hidden : MonoBehaviour
{
    [HideInInspector] public StealthWorld theworld;

    public void Start()
    {
        theworld = GameObject.FindGameObjectWithTag("World").GetComponent<StealthWorld>();
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "player")
        {
            print("Safe");
            theworld.Cover = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if(other.name == "player")
        {
            print("out of cover");
            theworld.Cover = false;
        }
    }
}
