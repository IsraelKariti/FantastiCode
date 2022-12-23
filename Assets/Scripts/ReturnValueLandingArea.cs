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
        if (intVal != null || pointerVal != null)
            return true;
        else
            return false;
    }

    public void OnLandingArea(GameObject go)
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        go.transform.parent = transform;


    }

}
