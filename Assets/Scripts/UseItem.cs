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
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (pressedbutton)
        {
            TextBox.ReloadScript(theText);
            TextBox.current_line = startLine;
            TextBox.endAtLine = endLine;
            TextBox.EnableTextBox();
            pressedbutton = false;
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
