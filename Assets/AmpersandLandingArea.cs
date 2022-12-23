using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmpersandLandingArea : MonoBehaviour, ILandingArea
{
    // check if the object that is being released on the landing area is supposed to be released there
    // for ex. address can't be released on an int
    public bool OnDraggableReleased(GameObject go)
    {
        // how do i check if the game object is an int???
        AmpersandOperator op = go.GetComponent<AmpersandOperator>();
        if (op != null)
            return true;
        else
            return false;
    }

    //once the object has been releaased
    public void OnLandingArea(GameObject go)
    {
        go.transform.parent = transform;
 
    }


}
