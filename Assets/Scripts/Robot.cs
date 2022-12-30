using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour, IDraggable
{
    public bool CheckIfPositionLegal(Vector3 pos)
    {
        Factory factory = transform.parent.GetComponent<Factory>();
        bool res = factory.CheckIfPositionInsideFactory(pos);
        return res;
    }

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
