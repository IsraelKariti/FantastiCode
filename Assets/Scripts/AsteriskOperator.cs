using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriskOperator : MonoBehaviour, IDraggable
{
    public GameObject OnDragged()
    {
        GameObject go = Instantiate(gameObject);
        go.name = "Asterisk";
        return go;
    }

    public void OnRejectedFromLandingArea()
    {
        Destroy(gameObject);
    }

}
