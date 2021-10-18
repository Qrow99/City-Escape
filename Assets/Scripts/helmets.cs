using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helmets : MonoBehaviour
{
    public GameOver death;
    public bool real;
    private bool touching;
    private bool readyToLoad;

    public TextBoxManager TextBox;
    public TextAsset theText;
    public int startLine;
    public int endLine;

    public Level_Loader levelLoader;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(touching && !real && Input.GetKeyDown(KeyCode.E))
        {
            death.Deathscreen();
        }
        else if(touching && real && Input.GetKeyDown(KeyCode.E))
        {
            TextBox.ReloadScript(theText);
            TextBox.current_line = startLine;
            TextBox.endAtLine = endLine;
            TextBox.EnableTextBox();
            readyToLoad = true;
        }
        if (readyToLoad && !TextBox.isActive)
        {
            print("load level");
            levelLoader.LoadNextLevel();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        touching = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        touching = false;
    }
}
