using System.Collections;
using System.Collections.Generic;
using UnityEngine;
internal class PointerVal : MonoBehaviour, IDraggable
{
    // if the object was place on a landing area that is not suitable for it
    public void OnRejectedFromLandingArea()
    {
        Destroy(gameObject);
    }
    public GameObject OnDragged()
    {
        return Instantiate(gameObject);
    }
}