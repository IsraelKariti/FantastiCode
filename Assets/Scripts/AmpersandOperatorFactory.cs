using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpersandOperatorFactory : AmpersandOperator
{
    public override bool CheckIfPositionLegal(Vector3 pos)
    {
        // check if the ampersand is in factory
        return transform.parent.GetComponent<Factory>().CheckIfPositionInsideFactory(pos);
    }

    public override GameObject OnDragged()
    {
        GameObject go = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
        go.name = "Ampersand";
        return go;
    }
    public override void OnRejectedFromLandingArea()
    {
        Destroy(gameObject);
    }
}