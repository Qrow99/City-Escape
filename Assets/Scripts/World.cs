using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{
    public Transform player;
    public bool wiresused = false;
    public GameObject lights;
    public GameObject Red_Light;
    public GameObject walls;
    // Use this for initialization
    void Start()
    {
        lights = GameObject.FindGameObjectWithTag("Lights");
        walls = GameObject.Find("removable doors");
        Red_Light = GameObject.Find("Red Light");
        if (lights != null)
        {
            lights.SetActive(false);
        }
    }

    private void Update()
    {
        if(wiresused && lights != null)
        {
            lights.SetActive(true);
            Red_Light.SetActive(false);
        }
        if (wiresused && walls != null)
        {
            walls.SetActive(false);
        }
    }
}
