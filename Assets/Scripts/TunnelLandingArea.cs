using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelLandingArea : MonoBehaviour, ILandingArea
{
    public bool OnDraggableReleased(GameObject go)
    {
        // check if the go is int or ticket
        IntVal intVal = go.GetComponent<IntVal>();
        Ticket ticket = go.GetComponent<Ticket>();

        if (intVal == null && ticket == null)
            return false;

        return true;
    }

    public void OnLandingArea(GameObject go)
    {
        // make val child of tunnel
        go.transform.parent = transform;

        // change the text in the code logger
        CodeLogger codeLogger = transform.parent.parent.Find("CodeLogger").GetComponent<CodeLogger>();
        string varName = codeLogger.GetExtra();
        codeLogger.ClearExtra();
        codeLogger.AddLine("Factory2(" + varName + ")");

        // drive the value through the tunnel
        StartCoroutine(DriveThrought(go));

        
    }

    private IEnumerator DriveThrought(GameObject go)
    {
        {
            // drive down
            // find the down position
            GameObject downGO = transform.parent.Find("Down").gameObject;
            SpriteRenderer downSpriteRenderer = downGO.GetComponent<SpriteRenderer>();
            Bounds downBounds = downSpriteRenderer.bounds;
            Vector3 downCenter = downBounds.center;
            Vector3 downMin = downBounds.min;
            Vector3 dest = new Vector3(downCenter.x, downMin.y, downMin.z-0.2f);
            yield return DriveTo(go, dest);
        }
        {
            // drive right
            // find the right position
            GameObject rightGO = transform.parent.Find("Right").gameObject;
            SpriteRenderer rightSpriteRenderer = rightGO.GetComponent<SpriteRenderer>();
            Bounds rightBounds = rightSpriteRenderer.bounds;
            Vector3 rightCenter = rightBounds.center;
            Vector3 rightMax = rightBounds.max;
            Vector3 dest = new Vector3(rightMax.x, rightCenter.y, rightCenter.z - 0.2f);
            yield return DriveTo(go, dest);
        }

        {
            // drive up
            // find the up position
            GameObject rightGO = transform.parent.Find("Up").gameObject;
            SpriteRenderer rightSpriteRenderer = rightGO.GetComponent<SpriteRenderer>();
            Bounds rightBounds = rightSpriteRenderer.bounds;
            Vector3 rightCenter = rightBounds.center;
            Vector3 rightMax = rightBounds.max;
            Vector3 dest = new Vector3(rightCenter.x, rightMax.y, rightMax.z - 0.2f);
            yield return DriveTo(go, dest);
        }

        // transfer to the input of factory 2
        GameObject factory2GO = GameObject.Find("Factory2");
        Transform inputTransform = factory2GO.transform.Find("Input/LandingArea");
        go.transform.parent = inputTransform;

        // set the name of the input to "input"
        go.GetComponent<IRepresentable>().setRepresentation("input");

        // check if level finished
        GameObject gameManagerGameObject = GameObject.Find("GameManager");
        GameManager gameManager = gameManagerGameObject.GetComponent<GameManager>();
        gameManager.CheckLevelComplete();
    }

    private IEnumerator DriveTo(GameObject go, Vector3 dest)
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
