using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour, IDraggable
{
    public GameObject OnDragged()
    {
        return Instantiate(gameObject);
    }

    public void OnRejectedFromLandingArea()
    {
        Destroy(gameObject); 
    }

}
