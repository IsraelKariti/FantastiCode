using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TicketFactory : Ticket
{
    // ticket should only be dragged from return value - therefore it should be dragged itself without duplicating
    public override GameObject OnDragged()
    {
        localPos = transform.localPosition;

        // check if the ticket is in a box - return duplicate
        if (transform.parent.GetComponent<TicketLandingArea>() != null)
        {
            // create duplice
            GameObject dup = Instantiate(gameObject, transform.position, transform.rotation);
            dup.name = "Ticket";// fix name
            dup.GetComponent<IRepresentable>().setRepresentation(representation);

            // get current variable name
            string varName = transform.parent.parent.parent.Find("Button/Text").GetComponent<TMP_Text>().text;

            // log in code
            CodeLogger codeLogger = GetFactoryTransform().Find("CodeLogger").GetComponent<CodeLogger>();
            codeLogger.SetExtra(varName);

            return dup;
        }

        // check if the ticket is on the return value - return gameobject
        if (transform.parent.GetComponent<ReturnValueLandingArea>() != null)
            return gameObject;

        // check if the ticket is in the address position - return null
        return null;
    }

    private Transform GetFactoryTransform()
    {
        return transform.parent.parent.parent.parent.parent;
    }

    public override void OnRejectedFromLandingArea()
    {
        // if the ticket dragged from box
        if (transform.parent.GetComponent<ReturnValueLandingArea>() == null)
        {
            // remove text from code logger
            CodeLogger codeLogger = GetFactoryTransform().Find("CodeLogger").GetComponent<CodeLogger>();
            codeLogger.ClearExtra();

            Destroy(gameObject);
        }
        // check if ticket is dragged from a return value
        else
        {
            transform.localPosition = localPos;
        }
    }

    public override bool CheckIfPositionLegal(Vector3 pos)
    {
        Factory factory;

        // check if the ticket is in a box 
        if (transform.parent.GetComponent<TicketLandingArea>() != null)
        {
            factory = transform.parent.parent.parent.parent.GetComponent<Factory>();
        }
        else// if the ticket is dragged from return value
        {
            factory = transform.parent.GetComponent<Factory>();
        }
        bool res = factory.CheckIfPositionInsideFactoryOrNeutralArea(pos);
        return res;
    }
}
