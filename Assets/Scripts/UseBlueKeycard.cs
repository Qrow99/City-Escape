using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseBlueKeycard : MonoBehaviour
{
    private Transform player;
    static bool inrange;
    static bool pressedbutton;
    public TextBoxManager TextBox;
    public int startLine;
    public int endLine;
    public TextAsset theText;
    public bool loadsLevel;
    public bool activatesText;
    public Level_Loader levelLoader;
    private bool readyToLoad;
    static inventory inv;
    static World theworld;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        inv = player.GetComponent<inventory>();
        theworld = GameObject.FindGameObjectWithTag("World").GetComponent<World>();
    }

    void Update()
    {
        if (pressedbutton)
        {
            if (activatesText)
            {
                TextBox.ReloadScript(theText);
                TextBox.current_line = startLine;
                TextBox.endAtLine = endLine;
                TextBox.EnableTextBox();
                pressedbutton = false;

            }
            if (loadsLevel)
            {
                readyToLoad = true;
            }
        }

        if (readyToLoad && loadsLevel)
        {
            print("load level");
            levelLoader.LoadNextLevel();
        }
    }

    public void Use()
    {
        if (inrange && theworld.wiresused)
        {
            print("test");
            pressedbutton = true;
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "player")
        {
            inrange = true;
            return;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.name == "player")
        {
            inrange = false;
            return;
        }
    }
}
