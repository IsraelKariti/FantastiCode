using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaAsteriskOperator : MonoBehaviour, IDraggable
{
    Vector3 startPos;
    public GameObject OnDragged()
    {
        startPos = transform.position;
        return gameObject;
    }

    public void OnRejectedFromLandingArea()
    {
        transform.position = startPos;
    }
}
