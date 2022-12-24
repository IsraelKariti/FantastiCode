using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteriskOperator : MonoBehaviour, IDraggable
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
