using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour, IDraggable
{
    public GameObject OnDragged()
    {
        GameObject go = Instantiate(gameObject);
        go.name = "Robot";
        return go;
    }

    public void OnRejectedFromLandingArea()
    {
        Destroy(gameObject); 
    }

}
