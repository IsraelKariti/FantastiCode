using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ticket : MonoBehaviour, IDraggable, IRepresentable
{
    Vector3 localPos;
    string representation;

    public string getRepresentation()
    {
        return representation;
    }

    public void setRepresentation(string r)
    {
        representation = r;
    }

    // ticket should only be dragged from return value - therefore it should be dragged itself without duplicating
    public GameObject OnDragged()
    {
        localPos = transform.localPosition;

        // check if the ticket is in a box - return duplicate
        if (transform.parent.GetComponent<PointerVariableLandingArea>() != null)
        {
            // create duplice
            GameObject dup = Instantiate(gameObject);
            dup.name = "Ticket";// fix name
            dup.GetComponent<IRepresentable>().setRepresentation(representation);

            // get current variable name
            string varName = transform.parent.parent.parent.Find("Button/Text").GetComponent<TMP_Text>().text;

            // log in code
            CodeLogger codeLogger = GameObject.Find("CodeLogger").GetComponent<CodeLogger>();
            codeLogger.SetExtra(varName);

            return dup;
        }

        // check if the ticket is on the return value - return gameobject
        if (transform.parent.GetComponent<ReturnValueLandingArea>() != null)
            return gameObject;

        // check if the ticket is in the address position - return null
        return null;
    }

    public void OnRejectedFromLandingArea()
    {
        // check if ticket is dragged from a box
        if (transform.parent != null)
        {
            transform.localPosition = localPos;
        }
        else
        {
            // remove text from code logger
            CodeLogger codeLogger = GameObject.Find("CodeLogger").GetComponent<CodeLogger>();
            codeLogger.ClearExtra();

            Destroy(gameObject);

        }


        // upon rejection ticket should get back to 
    }


}
