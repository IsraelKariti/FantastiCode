using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntValFactory : IntVal
{
    public override void OnRejectedFromLandingArea()
    {
        // if dragged from return value
        if (transform.parent != null && transform.parent.GetComponent<ReturnValueLandingArea>() != null)
        {
            transform.position = startPos;
        }
        else
        {// if dragged from box
            // remove text from code logger
            CodeLogger codeLogger = GameObject.Find("CodeLogger").GetComponent<CodeLogger>();
            codeLogger.ClearExtra();

            Destroy(gameObject);

        }
    }

    public override GameObject OnDragged()
    {
        // if dragged from box
        if (transform.parent.GetComponent<IntVariableLandingArea>() != null)
        {
            // create duplicate
            GameObject dup = Instantiate(gameObject, transform.position, transform.rotation);
            dup.name = "IntVal";
            dup.GetComponent<IRepresentable>().setRepresentation(representation);

            // delete childred of the return value landing area
            ClearLandingArea();

            // log in code
            CodeLogger codeLogger = transform.parent.parent.parent.parent.parent.Find("CodeLogger").GetComponent<CodeLogger>();
            codeLogger.SetExtra(representation);

            return dup;
        }
        else
        {// if dragged from return value
            startPos = transform.position;
            return gameObject;
        }
    }

    protected override void ClearLandingArea()
    {
        GameObject returnValueLandingArea = transform.parent.parent.parent.parent.parent.Find("LandingArea").gameObject;

        if (returnValueLandingArea != null)
            foreach (Transform t in returnValueLandingArea.transform)
                Destroy(t.gameObject);
    }

    public override bool CheckIfPositionLegal(Vector3 pos)
    {
        Factory factory;
        // if dragged from return value
        if (transform.parent != null)
        {
            factory = transform.parent.GetComponent<Factory>();
        }
        else
        {// if dragged from box (//land //open // int //factory)
            factory = transform.parent.parent.parent.parent.GetComponent<Factory>();
        }

        bool res = factory.CheckIfPositionInsideFactory(pos);
        return res;
    }
}
