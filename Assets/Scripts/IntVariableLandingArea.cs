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
        CodeLogger codeLogger = GameObject.Find("CodeLogger").GetComponent<CodeLogger>();

        // get current variable name (from top container variable - because value may be missing)
        string currRepresentation = transform.parent.parent.GetComponent<IRepresentable>().getRepresentation();

        // get landing draggable variable name
        string landingRepresention = go.GetComponent<IRepresentable>().getRepresentation();

        // check if the released draggable is different from the landing area
        if (currRepresentation.Equals(landingRepresention) == false) 
        {
            // get int value
            string str = go.transform.Find("ValText").GetComponent<TMP_Text>().text;

            //set string to this val(for visual)
            GameObject txt = transform.Find("IntVal/ValText").gameObject;
            txt.GetComponent<TMP_Text>().text = str;

            // update the code logger
            codeLogger.AddLine(currRepresentation + " = " + landingRepresention);

        }
        else// clean the logger from the dragged extra
        {
            codeLogger.ClearExtra();
        }

        // destroy draggable
        Destroy(go);

        // check if level complete
        GameObject.Find("GameManager").GetComponent<GameManager>().CheckLevelComplete();

    }


}
