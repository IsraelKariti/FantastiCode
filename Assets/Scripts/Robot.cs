using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour, IDraggable
{
    public virtual bool CheckIfPositionLegal(Vector3 pos)
    {
        return true;
    }

    public virtual GameObject OnDragged()
    {
        GameObject go = Instantiate(gameObject, transform.position, transform.rotation);
        go.name = "Robot";

        return go;
    }

    public virtual void OnRejectedFromLandingArea()
    {
        Destroy(gameObject); 
    }

}
