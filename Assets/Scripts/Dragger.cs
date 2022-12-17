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
            //Debug.Log("mouse down");

            if (selectedObject == null)
            {
                RaycastHit hit = CastRay();
                if (hit.collider != null)
                {
                    if (!hit.collider.CompareTag("draggable"))
                        return;

                    selectedObject = hit.collider.gameObject;
                    startDragPos = selectedObject.transform.position;

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

                if (ProximityCheck())
                {

                    // snap to destination
                    selectedObject.transform.position = startDragPos;

                    // let go
                    selectedObject = null;
                }
                else// if released operator in the wrong place
                {
                    //Debug.Log("operator outside");

                    selectedObject.transform.position = startDragPos;
                    // let go
                    selectedObject = null;

                }

            }
        }
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
