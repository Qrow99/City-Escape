using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MindTriggers : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public MindWorld theworld;
    public GameObject currentobject;
    private bool inrange;
    public void Start()
    {
        theworld = GameObject.FindGameObjectWithTag("World").GetComponent<MindWorld>();
    }

    public void Update()
    {
        if(inrange)
        {
            if (Input.GetKeyDown("e") || Input.GetKeyDown("space"))
            {
                if (gameObject.name == "gun")
                {
                    theworld.gun = true;
                    print("1");
                }

                if (gameObject.name == "medkit small")
                {
                    print("2");
                    theworld.MRE = true;
                }

                if (gameObject.name == "Toast")
                {
                    print("3");
                    theworld.Toast = true;
                }

                if (gameObject.name == "Eye")
                {
                    print("4");
                    theworld.Eye = true;
                }
                
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inrange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inrange = false;
    }
}
