using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class CodeLogger : MonoBehaviour
{
    string log;

    bool isUnfinishedLine;

    string extra;

    TMP_Text tmp_text;

    int counter = 0;

    private void Start()
    {
        counter = 0;
        tmp_text = transform.Find("Text").GetComponent<TMP_Text>();
    }

    // set text of an unfinished line
    public void SetExtra(string str)
    {

        // delete the old exrtra
        extra = str;
        isUnfinishedLine = true;

        // set the log with the new extra
        tmp_text.text = log  + extra;
    }

    internal void ClearExtra()
    {
        extra = "";
        isUnfinishedLine = false;

        tmp_text.text = log;
    }

    public string GetExtra()
    {
        return extra;
    }

   
    public void AddLine(string str)
    {
        ClearFirstLine();

        counter++;

        log = log + str + "\n";

        isUnfinishedLine = false;

        extra = "";

        tmp_text.text = log;
    }

    private void ClearFirstLine()
    {
        if(counter == 4)
        {
            string[] lines = log.Split("\n");

            lines[0] = lines[1];
            lines[1] = lines[2];
            lines[2] = lines[3];

            log = lines[0] + "\n" + lines[1] + "\n" + lines[2] + "\n";

            // decrease to 3
            counter--;
        }
    }
}
