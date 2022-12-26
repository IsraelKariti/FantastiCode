using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntVariableLandingArea : MonoBehaviour, ILandingArea
{
    // check if the object that is being released on the landing area is supposed to be released there
    // for ex. address can't be released on an int
    public bool OnDraggableReleased(GameObject go)
    {
        // how do i check if the game object is an int???
        IntVal intVal = go.GetComponent<IntVal>();
        if (intVal != null)
            return true;
        else
            return false;
    }

    // implemantaion of ILandingArea
    public void OnLandingArea(GameObject go)
    {
        // get int value
        string str = go.transform.Find("ValText").GetComponent<TMP_Text>().text;
        string landingRepresention = go.GetComponent<IRepresentable>().getRepresentation();

        //set string to this val(for visual)
        GameObject txt = transform.Find("IntVal/ValText").gameObject;
        txt.GetComponent<TMP_Text>().text = str;

        // get current variable name (from top container variable - because value may be missing)
        string currRepresentation = transform.parent.parent.GetComponent<IRepresentable>().getRepresentation();

        // update the code logger
        CodeLogger codeLogger = GameObject.Find("CodeLogger").GetComponent<CodeLogger>();

        codeLogger.AddLine(currRepresentation + " = " + landingRepresention);

        Destroy(go);

        GameObject.Find("GameManager").GetComponent<GameManager>().CheckLevelComplete();

    }


}
