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
    private bool visited = false;

    public GameObject Rubyneutral;
    public GameObject Rubyannoyed;
    public GameObject Rubypissed;
    // Start is called before the first frame update
    void Start()
    {
        textbox.SetActive(false);
        Rubyannoyed.SetActive(false);
        Rubypissed.SetActive(false);
        Rubyneutral.SetActive(false);
        player = FindObjectOfType<PlayerMovement>();
        if (textfile != null)
        {
            textlines = (textfile.text.Split('\n'));
        }

        if(endAtLine == 0)
        {
            endAtLine = textlines.Length - 1;
        }

        if (isActive && !visited)
        {
            EnableTextBox();
            visited = true;
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
            player.canMove = true;
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
                    selectportrait();
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
        int letter = 2;
        theText.text = "";
        isTyping = true;
        cancelTyping = false;
        while (isTyping && !cancelTyping && (letter < lineOfText.Length-1))
        {
            theText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typespeed);
        }
        theText.text = lineOfText.Substring(2);
        isTyping = false;
        cancelTyping = false;
    }

    public void EnableTextBox()
    {
        textbox.SetActive(true);
        selectportrait();
        isActive = true;
        if(StopPlayer)
        {
            player.canMove = false;
        }

        StartCoroutine(TextScroll(textlines[current_line]));
    }

    public void DisableTextBox()
    {
        Rubyannoyed.SetActive(false);
        Rubypissed.SetActive(false);
        Rubyneutral.SetActive(false);
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

    public void selectportrait() //when using portraits, if a line does not need a portrait, start it with a 0
    {
        if (textlines[current_line][2] == 'R' || textlines[current_line][2] == 'A' || textlines[current_line][2] == 'P' || textlines[current_line][2] == 'V')
        {
            if (textlines[current_line][0] == 'A') //A = Annoyed
            {
                Rubyannoyed.SetActive(true);
                Rubypissed.SetActive(false);
                Rubyneutral.SetActive(false);
            }
            else if (textlines[current_line][0] == 'P') //P = pissed
            {
                Rubypissed.SetActive(true);
                Rubyannoyed.SetActive(false);
                Rubyneutral.SetActive(false);
            }
            else if (textlines[current_line][0] == 'N') //N = neutral
            {
                Rubyneutral.SetActive(true);
                Rubyannoyed.SetActive(false);
                Rubypissed.SetActive(false);
            }
            else if (textlines[current_line][0] == '0')
            {
                Rubyannoyed.SetActive(false);
                Rubypissed.SetActive(false);
                Rubyneutral.SetActive(false);
            }
        }
        else
        {
            Rubyannoyed.SetActive(false);
            Rubypissed.SetActive(false);
            Rubyneutral.SetActive(false);
        }
    }
}
