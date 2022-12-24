using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class PointerVariableLandingArea : MonoBehaviour, ILandingArea
{
    // check if the object that is being released on the landing area is supposed to be released there
    // for ex. pointer can't be released on an int
    public bool OnDraggableReleased(GameObject go)
    {
        // how do i check if the game object is an int???
        PointerVal pointerVal = go.GetComponent<PointerVal>();
        Ticket ticket = go.GetComponent<Ticket>();
        if (pointerVal != null || ticket!=null)
            return true;
        else
            return false;
    }

    // implemantaion of ILandingArea
    public void OnLandingArea(GameObject go)
    {
        foreach(Transform transform in transform)
        {
            Destroy(transform.gameObject);
        }

        // get int value
        go.transform.parent = transform;
        go.transform.localPosition = new Vector3(go.transform.localPosition.x, go.transform.localPosition.y, -1f);
    }


}
