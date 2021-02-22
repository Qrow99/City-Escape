using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour
{
    public GameObject textbox;

    public Text theText;

    public TextAsset textfile;
    public string[] textlines;

    public int current_line;
    public int endAtLine;

    public bool isActive;
    public bool StopPlayer;

    private bool isTyping = false;
    private bool cancelTyping = false;

    public float typespeed;

    public PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        textbox.SetActive(false);
        player = FindObjectOfType<PlayerMovement>();
        if (textfile != null)
        {
            textlines = (textfile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textlines.Length - 1;
        }

        if (isActive)
        {
            EnableTextBox();
        }

        else
        {
            DisableTextBox();
        }
    }

    void Update()
    {
        if(!isActive)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.Mouse0) && textbox.activeSelf)
        {
            if (!isTyping)
            {

                current_line++;
                if (current_line > endAtLine)
                {
                    DisableTextBox();
                }
                else
                {
                    StartCoroutine(TextScroll(textlines[current_line]));
                }
            }
            else if(isTyping &&  !cancelTyping)
            {
                cancelTyping = true;
            }
        }
    }

    private IEnumerator TextScroll (string lineOfText)
    {
        int letter = 0;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length-1))
        {
            theText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typespeed);
        }
        theText.text = lineOfText;
        isTyping = false;
        cancelTyping = false;
    }

    public void EnableTextBox()
    {
        textbox.SetActive(true);
        isActive = true;
        if(StopPlayer)
        {
            player.canMove = false;
        }

        StartCoroutine(TextScroll(textlines[current_line]));
    }

    public void DisableTextBox()
    {
        textbox.SetActive(false);
        isActive = false;
        player.canMove = true;
    }

    public void ReloadScript(TextAsset theText)
    {
        if(theText != null)
        {
            textlines = new string[1];
            textlines = (theText.text.Split('\n'));
        }
    }
}
