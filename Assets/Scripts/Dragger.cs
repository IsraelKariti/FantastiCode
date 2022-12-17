using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragger : MonoBehaviour
{
    //public Cabinet cabinet;
    private GameObject selectedObject;
    private Vector3 startDragPos;
    private Vector3 destPos;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit[] hits = CastRays();

            // check if there is a door in the collider list
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("draggable"))
                        continue;

                    IDraggable draggable = hit.collider.gameObject.GetComponent<IDraggable>();

                    selectedObject = draggable.OnDragged(); ;
                    startDragPos = selectedObject.transform.position;

                    return;
                }
            }
        }

        // make object follow mouse
        if (selectedObject != null)
        {
            //Debug.Log("latch...");
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.WorldToScreenPoint(selectedObject.transform.position).z);

            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(position);

            selectedObject.transform.position = new Vector3(worldPosition.x, worldPosition.y, worldPosition.z);
        }

        if (Input.GetMouseButtonUp(0))
        {

            if (selectedObject != null)
            {
                // check if the target landing area is designed to accept this draggable
                GameObject targetLandingArea = TargetCheck();
                if (targetLandingArea != null)
                {
                    ILandingArea landingArea = targetLandingArea.GetComponent<ILandingArea>();
                    landingArea.OnLandingArea(selectedObject);
                }
                else
                {
                    IDraggable draggable = selectedObject.GetComponent<IDraggable>();
                    draggable.OnRejectedFromLandingArea();
                }
            }
        }
    }

    private GameObject TargetCheck()
    {
        RaycastHit[] hits = CastRays();
        foreach (RaycastHit hit in hits)
        {
            if (hit.collider != null)
            {

                // check if the game object is released on a landing area
                if (!hit.collider.CompareTag("landingArea"))
                    continue;

                // check if the landing area is suitable to the landing object
                ILandingArea landingArea = hit.collider.gameObject.GetComponent<ILandingArea>();
                if (landingArea.OnDraggableReleased(selectedObject))
                {
                    return hit.collider.gameObject;
                }


                
            }
        }
        return null;
    }

    private bool ProximityCheck()
    {

        Vector2 position2D = new Vector2(selectedObject.transform.position.x, selectedObject.transform.position.y);
        Vector2 dest2D = new Vector2(destPos.x, destPos.y);
        float dis = Vector2.Distance(position2D, dest2D);

        if (dis < 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private RaycastHit[] CastRays()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane
            );


        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane
            );

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit[] hits = Physics.RaycastAll(worldMousePosNear, worldMousePosFar - worldMousePosNear);

        return hits;
    }
    private RaycastHit CastRay()
    {
        Vector3 screenMousePosFar = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.farClipPlane
            );


        Vector3 screenMousePosNear = new Vector3(
            Input.mousePosition.x,
            Input.mousePosition.y,
            Camera.main.nearClipPlane
            );

        Vector3 worldMousePosFar = Camera.main.ScreenToWorldPoint(screenMousePosFar);
        Vector3 worldMousePosNear = Camera.main.ScreenToWorldPoint(screenMousePosNear);

        RaycastHit hit;
        Physics.Raycast(worldMousePosNear, worldMousePosFar - worldMousePosNear, out hit);

        return hit;
    }


}
