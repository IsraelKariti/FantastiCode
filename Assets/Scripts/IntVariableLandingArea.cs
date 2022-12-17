using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IntVariableLandingArea : MonoBehaviour, ILandingArea
{
    public void OnLandingArea(GameObject go)
    {
        // get int value
        string str = go.transform.Find("ValText").GetComponent<TMP_Text>().text;


        //set string to this val

        transform.parent.Find("BoxOpen/Val/ValText").GetComponent<TMP_Text>().text = str;

        Destroy(go);
    }

}
