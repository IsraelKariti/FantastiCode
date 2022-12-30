using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    private void Start()
    {
        // get the image
        BoxCollider background = gameObject.GetComponent<BoxCollider>();
        Bounds bounds = background.bounds;

        // get image top right corner
        Vector3 max = bounds.max;

        // get the image bottom left corner
        Vector3 min = bounds.min;


        Debug.Log("max: " + max.x + "," + max.y);
        Debug.Log("min: " + min.x + "," + min.y);
    }
    public bool CheckIfPositionInsideFactory(Vector3 pos)
    {
        // get the image
        BoxCollider background = gameObject.GetComponent<BoxCollider>();
        Bounds bounds = background.bounds;

        // get image top right corner
        Vector3 max = bounds.max;

        // get the image bottom left corner
        Vector3 min = bounds.min;

        // check if the pos is between the corners
        if (pos.x > min.x && pos.x < max.x && pos.y > min.y &&  pos.y < max.y )
            return true;
        else
            return false;
    }
}
