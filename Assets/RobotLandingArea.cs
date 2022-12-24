using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotLandingArea : MonoBehaviour, ILandingArea
{
    public bool OnDraggableReleased(GameObject go)
    {
        Robot robot = go.GetComponent<Robot>();

        // check if the released object is s robot
        if (robot != null)
        {
            // check if the box is taken or not
            bool on = transform.parent.Find("CheckBox/CheckMark").gameObject.active;
            Debug.Log("on: " + on);

            if (on)
                return false;
            else
                return true;
        }
        else
            return false;
    }

    public void OnLandingArea(GameObject go)
    {
        //
        Debug.Log("robot landed");
    }

}
