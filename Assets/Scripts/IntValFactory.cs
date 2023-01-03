using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntValFactory : IntVal
{
    public override void OnRejectedFromLandingArea()
    {
        // if dragged from box
        if (transform.parent.GetComponent<IntVariableLandingArea>()!=null)
        {
            // remove text from code logger
            CodeLogger codeLogger = GetCodeLogger();// 
            codeLogger.ClearExtra();

            Destroy(gameObject);

        }
        // if dragged from return value or input or tunnel
        else
            transform.position = startPos;

    }

    private CodeLogger GetCodeLogger()
    {
        GameObject.Find("Factory1").transform.Find("CodeLogger").GetComponent<CodeLogger>();

        // find out in which factory this int exist

        // assume this int val is inside return value OR tunnel landing area
        Transform codeLoggerTransform = transform.parent.parent.parent.Find("CodeLogger");
        if(codeLoggerTransform!= null)
        {
            // assumption was correct
            return codeLoggerTransform.GetComponent<CodeLogger>();
        }

        // if assumption was incorrect than for sure the int val is inside a box
        return transform.parent.parent.parent.parent.parent.Find("CodeLogger").GetComponent<CodeLogger>();

    }

    public override GameObject OnDragged()
    {
        // if dragged from box
        if (transform.parent.GetComponent<IntVariableLandingArea>() != null)
        {
            // create duplicate
            GameObject dup = Instantiate(gameObject, transform.position, transform.rotation, transform.parent);
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
        GameObject returnValueLandingArea = transform.parent.parent.parent.parent.parent.Find("ReturnValue/LandingArea").gameObject;

        if (returnValueLandingArea != null)
            foreach (Transform t in returnValueLandingArea.transform)
                Destroy(t.gameObject);
    }

    public override bool CheckIfPositionLegal(Vector3 pos)
    {
        Factory factory;
        IntVariableLandingArea intVariableLandingArea = transform.parent.GetComponent<IntVariableLandingArea>();
        // if dragged from return value 
        if (intVariableLandingArea == null)
        {
            factory = transform.parent.parent.parent.GetComponent<Factory>();
        }
        else
        {// if dragged from box (//land //open // int //factory) the duplicate will be child of scene, and its parent will be null
            factory = transform.parent.parent.parent.parent.parent.GetComponent<Factory>();
        }

        bool res = factory.CheckIfPositionInsideFactoryOrNeutralArea(pos);
        return res;
    }
}
