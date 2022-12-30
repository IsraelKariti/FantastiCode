using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class PointerVariableLandingArea : MonoBehaviour, ILandingArea
{
    // check if the object that is being released on the landing area is supposed to be released there
    // for ex. pointer can't be released on an int
    public bool OnDraggableReleased(GameObject go)
    {
        // how do i check if the game object is an int???
        //PointerVal pointerVal = go.GetComponent<PointerVal>();
        Ticket ticket = go.GetComponent<Ticket>();
        if ( ticket!=null)
            return true;
        else
            return false;
    }

    // implemantaion of ILandingArea
    public void OnLandingArea(GameObject go)
    {
        // clear all previous children
        foreach(Transform t in transform)
        {
            if(t.gameObject != go)
                Destroy(t.gameObject);
        }

        // set address value as child of landing area 
        go.transform.parent = transform;
        go.transform.localPosition = new Vector3(go.transform.localPosition.x, go.transform.localPosition.y, -1f);

        // update logger

        // get current variable name
        string varName = transform.parent.parent.Find("Button/Text").GetComponent<TMP_Text>().text;

        // update the code logger
        CodeLogger codeLogger = GameObject.Find("CodeLogger").GetComponent<CodeLogger>();

        string loggerExtra = codeLogger.GetExtra();

        codeLogger.AddLine(varName + " = " + loggerExtra);

        GameObject gameManagerGameObject = GameObject.Find("GameManager");
        GameManager gameManager = gameManagerGameObject.GetComponent<GameManager>();
        gameManager.CheckLevelComplete();
    }


}
