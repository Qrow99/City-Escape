using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseItem : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && this.name != "GiveMedkit")
        {
            print(this.name);
            Use();
        }
        if (pressedbutton)
        {
            if(activatesText)
            {
                TextBox.ReloadScript(theText);
                TextBox.current_line = startLine;
                TextBox.endAtLine = endLine;
                TextBox.EnableTextBox();
                pressedbutton = false;

            }
            if(loadsLevel)
            {
                readyToLoad = true;
            }
        }

        if(readyToLoad && loadsLevel && !TextBox.isActive)
        {
            print("load level");
            levelLoader.LoadNextLevel();
        }
    }

    public void Use()
    {
        if (inrange)
        {
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
