using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class RobotLandingArea : MonoBehaviour, ILandingArea
{

    private void Start()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);

        BoxCollider boxCollider = GetComponent<BoxCollider>();
        boxCollider.center = new Vector3(-3.1f, 0, 0);
        boxCollider.size = new Vector3(9.2f, 1.6f, 1);
    }
    public virtual bool OnDraggableReleased(GameObject go)
    {
        Robot robot = go.GetComponent<Robot>();

        // check if the released object is s robot
        if (robot != null)
        {
            // check if the box exist or not
            Transform fullTicketTransform = transform.parent.Find("Ticket/TicketFull");
            if (fullTicketTransform == null)
                return false;

            bool on = fullTicketTransform.gameObject.active;
            //Debug.Log("on: " + on);

            return on;
        }
        else
            return false;
    }

    public virtual void OnLandingArea(GameObject robot)
    {
        //
        //Debug.Log("robot landed");

        // make robot the child of the landing area
        robot.transform.parent = transform;

        StartCoroutine(AnimateRobot(robot));

        // log in code
        CodeLogger codeLogger = GameObject.Find("CodeLogger").GetComponent<CodeLogger>();
        codeLogger.SetExtra("malloc");
    }

    protected virtual IEnumerator AnimateRobot(GameObject robot)
    {
        // make the robot NOT DRAGGABLE
        Destroy(robot.GetComponent<BoxCollider>());

        // animate robot to ticket
        Bounds ticketBounds = transform.parent.Find("Ticket").GetComponent<SpriteRenderer>().bounds;
        Vector3 robotDestPosAtTicket = ticketBounds.center - new Vector3(ticketBounds.size.x - 0.3f, 0, 1f);
        yield return AnimateRobotToGlobalPosWithConstantSpeed(robot, robotDestPosAtTicket);

        // punch a hole in the ticket (disable the full ticket)
        transform.parent.Find("Ticket/TicketFull").gameObject.SetActive(false);

        // poop closed box
        yield return InflateClosedBox();

        transform.parent.Find("ConnectorBoxTicket").gameObject.SetActive(true);

        // duplicate ticket
        //string ticketRepresentation = transform.parent.GetComponent<IRepresentable>().getRepresentation();
        GameObject ticketDup = Instantiate(transform.parent.Find("Ticket").gameObject, robot.transform);
        ticketDup.name = "Ticket";
        ticketDup.GetComponent<IRepresentable>().setRepresentation("malloc");
        ticketDup.transform.localPosition = new Vector3(2f, 0.1f, 1f);

        // animate robot to the return value
        Transform returnValueTransform = GameObject.Find("ReturnValue/LandingArea").transform;
        Vector3 destPosAtReturnValue = returnValueTransform.position;
        yield return AnimateRobotToGlobalPosWithConstantSpeed(robot, new Vector3(destPosAtReturnValue.x-2f, destPosAtReturnValue.y, destPosAtReturnValue.z-3));

        // make ticket the child of the return value
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

    protected virtual IEnumerator InflateClosedBox()
    {
        // get orig and dest
        Transform closedBoxTransform = transform.parent.Find("BoxClosed");
        Vector3 closedBoxFullScale = new Vector3(0.2f, 0.2f, 1f);
        Vector3 closedBoxSlimScale =new Vector3(0.01f, closedBoxFullScale.y, closedBoxFullScale.z);

        Vector3 closedBoxStartPos = closedBoxTransform.localPosition + new Vector3(1f, 0, 0);
        Vector3 closedBoxEndPos = closedBoxTransform.localPosition;

        // activate
        closedBoxTransform.gameObject.SetActive(true);

        float timePassed = 0;

        float fraction = 0;
        float animTime = 1f;

        while (fraction < 1)
        {
            timePassed += Time.deltaTime;
            fraction = timePassed / animTime;

            closedBoxTransform.localScale = Vector3.Lerp(closedBoxSlimScale, closedBoxFullScale, fraction);
            closedBoxTransform.localPosition = Vector3.Lerp(closedBoxStartPos, closedBoxEndPos, fraction);
            yield return null;
        }

        yield return null;
    }

    protected virtual IEnumerator AnimateRobotToLocalPos(GameObject go, Vector3 dest)
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
    protected virtual IEnumerator AnimateRobotToGlobalPos(GameObject go, Vector3 dest)
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

    // here the animation is not dependant on the time, but on the speed
    protected virtual IEnumerator AnimateRobotToGlobalPosWithConstantSpeed(GameObject go, Vector3 dest)
    {
        float speed = 10;// speed of object is 1 meter per second 1m/s

        Vector3 startGlobalPos = go.transform.position;
        Vector3 endGlobalPos = dest;

        // calculate the distance between orig and dest
        float dist = Vector3.Distance(startGlobalPos, endGlobalPos);

        float passedDist = 0;

        float fraction = 0;

        while (fraction<1)
        {
            // the time passed in curr frame
            float frameTime = Time.deltaTime;

            // the distance passed in this frame time
            float frameDist = frameTime * speed;

            // the accumulative distance that was passed
            passedDist += frameDist;

            //the fraction of the distance that was passed
            fraction = passedDist / dist;

            go.transform.position = Vector3.Lerp(startGlobalPos, endGlobalPos, fraction);
            yield return null;
        }

    }

}
