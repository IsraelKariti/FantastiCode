using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpersandOperator : MonoBehaviour, IDraggable
{
    public virtual bool CheckIfPositionLegal(Vector3 pos)
    {
            return true;
    }

    public virtual GameObject OnDragged()
    {
        GameObject go = Instantiate(gameObject, transform.position, transform.rotation);
        go.name = "Ampersand";
        return go;
    }
    public virtual void OnRejectedFromLandingArea()
    {
        Destroy(gameObject);
    }


}