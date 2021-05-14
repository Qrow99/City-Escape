using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stealth : MonoBehaviour
{
    [HideInInspector] public StealthWorld theworld;
    [HideInInspector] public bool seen = false;
    public GameOver death;
    public void Start()
    {
        theworld = GameObject.FindGameObjectWithTag("World").GetComponent<StealthWorld>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        seen = true;
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        seen = false;
    }

    public void Update()
    {
        if (!theworld.Cover && seen)
        {
            print("U dead as hell");
            death.Deathscreen();
        }
    }

}
