using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntVal : MonoBehaviour, IDraggable, IRepresentable
{
    protected Vector3 startPos;
    protected string representation;

    public virtual void OnRejectedFromLandingArea()
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
    public virtual GameObject OnDragged()
    {
        // if dragged from box
        if (transform.parent.GetComponent<IntVariableLandingArea>() != null)
        {
            // create duplicate
            GameObject dup = Instantiate(gameObject, transform.position, transform.rotation);
            dup.name = "IntVal";
            dup.GetComponent<IRepresentable>().setRepresentation(representation);

            // delete childred of the return value landing area
            ClearLandingArea();

            // log in code
            CodeLogger codeLogger = GameObject.Find("CodeLogger").GetComponent<CodeLogger>();
            codeLogger.SetExtra(representation);

            // close box
            transform.parent.parent.parent.Find("BoxOpen").gameObject.SetActive(false);
            transform.parent.parent.parent.Find("BoxClosed").gameObject.SetActive(true);


            // reset representation
            transform.parent.parent.parent.GetComponent<IRepresentable>().setRepresentation("");

            return dup;
        }
        else
        {// if dragged from return value
            startPos = transform.position;
            return gameObject;
        }
    }

    protected virtual void ClearLandingArea()
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

    public virtual bool CheckIfPositionLegal(Vector3 pos)
    {
        return true;
    }
}
