using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotLandingAreaFactory : RobotLandingArea
{
    public override void OnLandingArea(GameObject go)
    {
        // make robot the child of the landing area
        go.transform.parent = transform;

        StartCoroutine(AnimateRobot(go));

        // log in code
        CodeLogger codeLogger = transform.parent.parent.parent.Find("CodeLogger").GetComponent<CodeLogger>();
        codeLogger.SetExtra("malloc");
    }

    protected override IEnumerator AnimateRobot(GameObject robot)
    {
        // get the empty check mark
        Transform checkMarkTransform = transform.parent.Find("CheckBox/CheckMark");
        Bounds checkMarkBounds = checkMarkTransform.GetComponent<SpriteRenderer>().bounds;

        // calculate the destination position of the robot on the checkbox 
        Vector3 robotDestPosAtCheckBox = checkMarkBounds.center - new Vector3(checkMarkBounds.size.x, 0, 0);

        // animate robot to check box
        yield return AnimateRobotToGlobalPos(robot, robotDestPosAtCheckBox);

        // actually check the box
        checkMarkTransform.gameObject.SetActive(true);

        // turn on the closed box (simulate allocation)
        transform.parent.GetChild(1).gameObject.SetActive(true);

        // animate robot to ticket
        Bounds ticketBounds = transform.parent.Find("Ticket/TicketBackground").GetComponent<SpriteRenderer>().bounds;
        Vector3 robotDestPosAtTicket = ticketBounds.center - new Vector3(ticketBounds.size.x, 0, 0);
        yield return AnimateRobotToGlobalPos(robot, robotDestPosAtTicket);

        // duplicate ticket
        GameObject ticketOrig = transform.parent.Find("Ticket").gameObject;
        GameObject ticketDup = Instantiate(ticketOrig, ticketOrig.transform.position, ticketOrig.transform.rotation, robot.transform);
        ticketDup.name = "Ticket";
        ticketDup.GetComponent<IRepresentable>().setRepresentation("malloc");

        // animate robot to the return value
        Vector3 destPosAtReturnValue = CalcDestPosAtReturnValue(robot, ticketDup);
        yield return AnimateRobotToGlobalPos(robot, new Vector3(destPosAtReturnValue.x, destPosAtReturnValue.y, destPosAtReturnValue.z - 3));

        // make ticket the child of the return value
        Transform returnValueTransform = transform.parent.parent.parent.Find("ReturnValue/LandingArea").transform;
        foreach (Transform t in returnValueTransform)
            Destroy(t.gameObject);
        robot.transform.Find("Ticket").parent = returnValueTransform;

        // set representation to return value
        returnValueTransform.GetComponent<ReturnValueLandingArea>().representation = "malloc";

        // destroy robot
        Destroy(robot);

        // check if level finished
        GameObject gameManagerGameObject = GameObject.Find("GameManager");
        GameManager gameManager = gameManagerGameObject.GetComponent<GameManager>();
        gameManager.CheckLevelComplete();

        yield return null;
    }

    private Vector3 CalcDestPosAtReturnValue(GameObject robot, GameObject ticketDup)
    {
        // the center of the return value
        Transform returnValueTransform = transform.parent.parent.parent.Find("ReturnValue/LandingArea").transform;
        Vector3 destPosAtReturnValue = returnValueTransform.position;

        // the current center of the ticket
        Vector3 centerOfTicketDup = ticketDup.transform.position;

        // diff between them
        Vector3 diffToDest =destPosAtReturnValue- centerOfTicketDup;

        // robot curr position
        Vector3 robotCurrPos = robot.transform.position;

        // robot dest pos
        Vector3 robotDestPos = robotCurrPos + diffToDest;
        return robotDestPos;
    }
}
