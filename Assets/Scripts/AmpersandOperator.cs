using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpersandOperator : MonoBehaviour, IDraggable
{
    public GameObject OnDragged()
    {
        GameObject go = Instantiate(gameObject);
        go.name = "Ampersand";
        return go;
    }
    public void OnRejectedFromLandingArea()
    {
        Destroy(gameObject);
    }


}