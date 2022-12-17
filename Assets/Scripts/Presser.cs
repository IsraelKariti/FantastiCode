using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Presser : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit[] hits = CastRay();

            // check if there is a door in the collider list
            foreach (RaycastHit hit in hits)
            {
                if (hit.collider.CompareTag("pressable"))
                {
                    GameObject selectedObject = hit.collider.gameObject;

                        Pressable p = selectedObject.GetComponent<Pressable>();

                        p.OnPressed();
                        return;
                    
                }
            }

        }
    }

    private RaycastHit[] CastRay()
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
}
