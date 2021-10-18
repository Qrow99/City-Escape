using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindWorld : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public bool gun = false;
    [HideInInspector] public bool MRE = false;
    [HideInInspector] public bool Toast = false;
    [HideInInspector] public bool Eye = false;
    public GameObject next;
    public GameObject Tilemap;
    void Start()
    {
        next.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(gun && MRE && Toast && Eye)
        {
            next.SetActive(true);
            Tilemap.SetActive(false);
        }
    }
}
