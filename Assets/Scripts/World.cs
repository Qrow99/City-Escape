using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public Transform player;
    public bool wiresused = false;
    public GameObject lights;
    public GameObject walls;
    // Use this for initialization
    void Start()
    {
        lights = GameObject.FindGameObjectWithTag("Lights");
        walls = GameObject.Find("removable doors");
        if(lights != null)
        {
            lights.SetActive(false);
        }
    }

    private void Update()
    {
        if(wiresused && lights != null)
        {
            lights.SetActive(true);
        }
        if (wiresused && walls != null)
        {
            walls.SetActive(false);
        }
    }
}
