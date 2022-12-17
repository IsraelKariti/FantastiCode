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
        // check if the go is an int


        // get int value
        string str = go.transform.Find("ValText").GetComponent<TMP_Text>().text;

        //set string to this val
        GameObject txt = transform.parent.Find("BoxOpen/IntVal/ValText").gameObject;
        txt.GetComponent<TMP_Text>().text = str;

        Destroy(go);
    }


}
