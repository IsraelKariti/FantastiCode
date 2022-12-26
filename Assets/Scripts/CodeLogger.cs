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

    private void Start()
    {
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
        log = log + str + "\n";

        isUnfinishedLine = false;

        extra = "";

        tmp_text.text = log;
    }
}
