using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ticket : MonoBehaviour, IDraggable
{
    Vector3 localPos;
    // ticket should only be dragged from return value - therefore it should be dragged itself without duplicating
    public GameObject OnDragged()
    {
        localPos = transform.localPosition;

        // check if the ticket is in a box - return duplicate
        if (transform.parent.GetComponent<PointerVariableLandingArea>() != null)
            return Instantiate(gameObject);

        // check if the ticket is on the return value - return gameobject
        if (transform.parent.GetComponent<ReturnValueLandingArea>() != null)
            return gameObject;

        // check if the ticket is in the address position - return null
        return null;
    }

    public void OnRejectedFromLandingArea()
    {
        // check if ticket is dragged from a box
        //if(transform.parent.GetComponent<ReturnValueLandingArea>()!=null)
        if(transform.parent!=null)
            transform.localPosition = localPos;
        else
            Destroy(gameObject);


        // upon rejection ticket should get back to 
    }
}
