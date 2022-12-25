using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntVal : MonoBehaviour, IDraggable
{
    Vector3 startPos;

    public void OnRejectedFromLandingArea()
    {
        // if dragged from box
        if (transform.parent == null)
        {
            // remove text from code logger
            CodeLogger codeLogger = GameObject.Find("CodeLogger").GetComponent<CodeLogger>();
            codeLogger.ClearExtra();

            Destroy(gameObject);
        }
        else// if dragged from return value
        {
            transform.position = startPos;
        }
    }
    public GameObject OnDragged()
    {
        // if dragged from box
        if (transform.parent.GetComponent<IntVariableLandingArea>() != null)
        {
            // create duplicate
            GameObject go = Instantiate(gameObject);
            go.name = "IntVal";

            // delete childred of the return value landing area
            ClearLandingArea();

            // get current variable name
            string varName = transform.parent.parent.parent.Find("Button/Text").GetComponent<TMP_Text>().text;

            // log in code
            CodeLogger codeLogger = GameObject.Find("CodeLogger").GetComponent<CodeLogger>();
            codeLogger.SetExtra(varName);

            return go;
        }
        else
        {// if dragged from return value
            startPos = transform.position;
            return gameObject;
        }
    }

    private void ClearLandingArea()
    {
        GameObject returnValueLandingArea = GameObject.Find("ReturnValue/LandingArea");
        foreach (Transform t in returnValueLandingArea.transform)
            Destroy(t.gameObject);
    }
}
