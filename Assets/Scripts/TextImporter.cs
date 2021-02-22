using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextImporter : MonoBehaviour
{

    public TextAsset textfile;
    public string[] textlines;
    // Start is called before the first frame update
    void Start()
    {
        if( textfile != null)
        {
            textlines = (textfile.text.Split('\n'));
        }
    }

}
