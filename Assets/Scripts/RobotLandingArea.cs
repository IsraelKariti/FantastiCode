using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotLandingArea : MonoBehaviour, ILandingArea
{
    Vector3 robotDestPosAtCheckBox;
    Vector3 robotDestPosAtTicket;

    private void Start()
    {
        // change size of box collider
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        boxCollider.size = new Vector3(6, boxCollider.size.y, boxCollider.size.z);
    }
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

        // make robot the child of the landing area
        go.transform.parent = transform;

        StartCoroutine(AnimateRobot(go));

        // log in code
        CodeLogger codeLogger = GameObject.Find("CodeLogger").GetComponent<CodeLogger>();
        codeLogger.SetExtra("malloc");
    }

    private IEnumerator AnimateRobot(GameObject go)
    {
        // animate robot to check box
        Vector3 robotDestPosAtCheckBox = new Vector3(0.7f, 0, -3);

        yield return AnimateRobotToLocalPos(go, robotDestPosAtCheckBox);

        // check box
        transform.parent.Find("CheckBox/CheckMark").gameObject.SetActive(true);

        // turn on the closed box
        transform.parent.GetChild(1).gameObject.SetActive(true);

        // animate robot to ticket
        Vector3 robotDestPosAtTicket = new Vector3(-1f, 0.1f, -3);
        yield return AnimateRobotToLocalPos(go, robotDestPosAtTicket);

        // duplicate ticket
        //string ticketRepresentation = transform.parent.GetComponent<IRepresentable>().getRepresentation();
        GameObject ticketDup = Instantiate(transform.parent.Find("Ticket").gameObject, go.transform);
        ticketDup.name = "Ticket";
        ticketDup.GetComponent<IRepresentable>().setRepresentation("malloc");
        ticketDup.transform.localPosition = new Vector3(2f, 0.1f, 2f);

        // animate robot to the return value
        Transform returnValueTransform = GameObject.Find("ReturnValue/LandingArea").transform;
        Vector3 destPosAtReturnValue = returnValueTransform.position;
        yield return AnimateRobotToGlobalPos(go, new Vector3(destPosAtReturnValue.x-2f, destPosAtReturnValue.y, destPosAtReturnValue.z-3));

        // make ticket the child of the return value
        foreach (Transform t in returnValueTransform)
            Destroy(t.gameObject);
        go.transform.Find("Ticket").parent = returnValueTransform;

        // set representation to return value
        returnValueTransform.GetComponent<ReturnValueLandingArea>().representation = "malloc";

        // destroy robot
        Destroy(go);

        // check if level finished
        GameObject gameManagerGameObject = GameObject.Find("GameManager");
        GameManager gameManager = gameManagerGameObject.GetComponent<GameManager>();
        gameManager.CheckLevelComplete();

        yield return null;
    }

    private IEnumerator AnimateRobotToLocalPos(GameObject go, Vector3 dest)
    {
        float timePassed = 0;

        Vector3 startLocalPos = go.transform.localPosition;
        Vector3 endLocalPos = dest;

        float fraction = 0;
        float animTime = 1f;

        while (fraction < 1)
        {
            timePassed += Time.deltaTime;
            fraction = timePassed / animTime;

            go.transform.localPosition = Vector3.Lerp(startLocalPos, endLocalPos, fraction);
            yield return null;
        }

    }
    private IEnumerator AnimateRobotToGlobalPos(GameObject go, Vector3 dest)
    {
        float timePassed = 0;

        Vector3 startGlobalPos = go.transform.position;
        Vector3 endGlobalPos = dest;

        float fraction = 0;
        float animTime = 1f;

        while (fraction < 1)
        {
            timePassed += Time.deltaTime;
            fraction = timePassed / animTime;

            go.transform.position = Vector3.Lerp(startGlobalPos, endGlobalPos, fraction);
            yield return null;
        }

    }

}
