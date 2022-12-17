using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Val : MonoBehaviour, IDraggable
{
    public GameObject OnDragged()
    {
        return Instantiate(gameObject);
    }

}
