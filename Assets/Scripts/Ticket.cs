using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ticket : MonoBehaviour, IDraggable, IRepresentable
{
    protected Vector3 localPos;
    protected string representation;

    private PositionLegalityChecker positionLegalityChecker;

    public void SetPositionLegalityChecker(PositionLegalityChecker p)
    {
        positionLegalityChecker = p;
    }

    private void Start()
    {
        positionLegalityChecker = new CheckPositionWhenValIsInBoxOpenedBySelfFactory();
    }
    public string getRepresentation()
    {
        return representation;
    }

    public void setRepresentation(string r)
    {
        representation = r;
    }

    // ticket should only be dragged from return value - therefore it should be dragged itself without duplicating
    public virtual GameObject OnDragged()
    {
        localPos = transform.localPosition;

        // check if the ticket is in a box - return duplicate
        if (transform.parent.GetComponent<TicketLandingArea>() != null)
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
        
        // check if the ticket is on the input - return gameobject
        if (transform.parent.GetComponent<InputLandingArea>() != null)
            return gameObject;

        // check if the ticket is in the address position - return null
        return null;
    }

    public virtual void OnRejectedFromLandingArea()
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
    }
    public virtual bool CheckIfPositionLegal(Vector3 pos)
    {
        return positionLegalityChecker.CheckIfPositionLegal(gameObject, pos);
    }
}
