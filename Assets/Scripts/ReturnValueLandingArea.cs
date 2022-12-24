using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnValueLandingArea : MonoBehaviour, ILandingArea
{
    // check if the object that is being released on the landing area is supposed to be released there
    // for ex. operators can't be released on a return value (only int and address can!)
    public bool OnDraggableReleased(GameObject go)
    {
        // how do i check if the game object is an int???
        IntVal intVal = go.GetComponent<IntVal>();
        PointerVal pointerVal = go.GetComponent<PointerVal>();
        AsteriskOperator asterisk = go.GetComponent<AsteriskOperator>();
        if (intVal != null || pointerVal != null|| asterisk != null)
            return true;
        else
            return false;
    }

    public void OnLandingArea(GameObject go)
    {
        // check if the dropped object is asterik
        AsteriskOperator asterisk = go.GetComponent<AsteriskOperator>();
        if(asterisk != null)
        {
            // check if there is anything on the landing area
            
            if (transform.childCount>0)
            {
                // check if the object on the return value is a ticket
                Transform child = transform.GetChild(0);
                Ticket ticket = child.gameObject.GetComponent<Ticket>();
                if (ticket != null)
                {
                    Debug.Log("asterisk + address");
                    // create mega-asterisk


                }
            }

            Destroy(go);
            return;
        }

        // if the return value is int or pointer
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        go.transform.parent = transform;


    }

}
