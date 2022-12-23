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

        return gameObject;
    }

    public void OnRejectedFromLandingArea()
    {
        // upon rejection ticket should get back to 
        transform.localPosition = localPos;
    }
}
