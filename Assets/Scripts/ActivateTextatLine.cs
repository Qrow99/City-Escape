using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextatLine : MonoBehaviour
{

    public TextAsset theText;

    public int startLine;
    public int endLine;

    public TextBoxManager TextBox;

    public bool requireButtonPress;
    private bool waitForPress;

    public bool destroyWhenActivated;

    public bool destroyWhenFinished;

    private bool used = false;
    // Start is called before the first frame update
    void Start()
    {
        TextBox = FindObjectOfType<TextBoxManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(waitForPress && Input.GetKeyDown(KeyCode.E) && !used)
        {
            TextBox.ReloadScript(theText);
            TextBox.current_line = startLine;
            TextBox.endAtLine = endLine;
            TextBox.EnableTextBox();

            if (destroyWhenActivated)
            {
                Destroy(gameObject);
            }
            if(destroyWhenFinished)
            {
                used = true;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "player")
        {
            if(requireButtonPress)
            {
                waitForPress = true;
                return;
            }

            TextBox.ReloadScript(theText);
            TextBox.current_line = startLine;
            TextBox.endAtLine = endLine;
            TextBox.EnableTextBox();

            if(destroyWhenActivated)
            {
                Destroy(gameObject);
            }
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.name == "player")
        {
            waitForPress = false;
        }
    }
}
