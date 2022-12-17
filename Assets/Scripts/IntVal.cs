using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntVal : MonoBehaviour, IDraggable
{
    public void OnRejectedFromLandingArea()
    {
        Destroy(gameObject);
    }
    public GameObject OnDragged()
    {
        return Instantiate(gameObject);
    }


}
