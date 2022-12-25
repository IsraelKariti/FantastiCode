using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntVal : MonoBehaviour, IDraggable
{
    Vector3 startPos;

    public void OnRejectedFromLandingArea()
    {
        // if dragged from box
        if (transform.parent == null)
        {
            Destroy(gameObject);
        }
        else// if dragged from return value
        {
            transform.position = startPos;
        }
    }
    public GameObject OnDragged()
    {
        // if dragged from box
        if (transform.parent.GetComponent<IntVariableLandingArea>() != null)
        {
            GameObject go = Instantiate(gameObject);
            go.name = "IntVal";
            return go;
        }
        else
        {// if dragged from return value
            startPos = transform.position;
            return gameObject;
        }
    }


}
