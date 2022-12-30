using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFactory : Robot
{
    public override bool CheckIfPositionLegal(Vector3 pos)
    {
        Factory factory = transform.parent.GetComponent<Factory>();
        bool res = factory.CheckIfPositionInsideFactory(pos);
        return res;
    }

    public override GameObject OnDragged()
    {
        GameObject go = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
        go.name = "Robot";

        return go;
    }

    public override void OnRejectedFromLandingArea()
    {
        Destroy(gameObject);
    }
}
