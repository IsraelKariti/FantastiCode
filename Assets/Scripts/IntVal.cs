using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntVal : MonoBehaviour, IDraggable, IRepresentable
{
    Vector3 startPos;
    private string representation;
    private void Start()
    {
        //representation = "";
    }
    public void OnRejectedFromLandingArea()
    {
        // if dragged from return value
        if (transform.parent != null)
        {
            transform.position = startPos;

        }
        else
        {// if dragged from box
            // remove text from code logger
            CodeLogger codeLogger = GameObject.Find("CodeLogger").GetComponent<CodeLogger>();
            codeLogger.ClearExtra();

            Destroy(gameObject);

        }
    }
    public GameObject OnDragged()
    {
        // if dragged from box
        if (transform.parent.GetComponent<IntVariableLandingArea>() != null)
        {
            // create duplicate
            GameObject dup = Instantiate(gameObject);
            dup.name = "IntVal";
            dup.GetComponent<IRepresentable>().setRepresentation(representation);

            // delete childred of the return value landing area
            ClearLandingArea();

            // log in code
            CodeLogger codeLogger = GameObject.Find("CodeLogger").GetComponent<CodeLogger>();
            codeLogger.SetExtra(representation);
            
            return dup;
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

        if(returnValueLandingArea!=null)
            foreach (Transform t in returnValueLandingArea.transform)
                Destroy(t.gameObject);
    }

    public string getRepresentation()
    {
        return representation;
    }

    public void setRepresentation(string r)
    {
        representation = r;
    }
}
