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


       // Debug.Log("max: " + max.x + "," + max.y);
        //Debug.Log("min: " + min.x + "," + min.y);
    }

    // check if the position of the value is iside the factory or the neutral area
    // in other words check if the value is NOT in the OTHER FACTORY
    public bool CheckIfPositionInsideFactoryOrNeutralArea(Vector3 pos)
    {
        // FIND THE OTHER FACTORY
        Factory factory1 = GameObject.Find("Factory1").GetComponent<Factory>();
        Factory factory2 = GameObject.Find("Factory2").GetComponent<Factory>();

        Factory oponnetFactory = null;
        if (factory1 == this)
            oponnetFactory = factory2;
        else
            oponnetFactory = factory1;

        // get the image
        BoxCollider background = oponnetFactory.gameObject.GetComponent<BoxCollider>();
        Bounds bounds = background.bounds;

        // get image top right corner
        Vector3 max = bounds.max;

        // get the image bottom left corner
        Vector3 min = bounds.min;

        // check if the pos is between the corners
        if (pos.x > min.x && pos.x < max.x && pos.y > min.y &&  pos.y < max.y )
            return false;
        else
            return true;
    }
}
