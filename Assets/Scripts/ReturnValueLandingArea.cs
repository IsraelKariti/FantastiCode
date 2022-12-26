using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnValueLandingArea : MonoBehaviour, ILandingArea
{
    public GameObject megaAsteriskPrefab;


    public string representation;

    // check if the object that is being released on the landing area is supposed to be released there
    // for ex. operators can't be released on a return value (only int and address can!)
    public bool OnDraggableReleased(GameObject go)
    {
        // how do i check if the game object is an int???
        IntVal intVal = go.GetComponent<IntVal>();
        PointerVal pointerVal = go.GetComponent<PointerVal>();
        AsteriskOperator asterisk = go.GetComponent<AsteriskOperator>();
        Ticket ticket = go.GetComponent<Ticket>();

        if (intVal != null || pointerVal != null|| asterisk != null || ticket != null)
            return true;
        else
            return false;
    }

    public void OnLandingArea(GameObject go)
    {
        // check if the dropped object is asterik
        AsteriskOperator asterisk = go.GetComponent<AsteriskOperator>();
        if(asterisk != null)
        {
            // check if there is anything on the landing area
            
            if (transform.childCount>0)
            {
                // check if the object on the return value is a ticket
                Transform child = transform.GetChild(0);
                Ticket ticket = child.gameObject.GetComponent<Ticket>();
                if (ticket != null)
                {
                    // create mega-asterisk
                    Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 3);
                    GameObject megaAsterisk = Instantiate(megaAsteriskPrefab, pos, transform.rotation);
                    megaAsterisk.name = "Asterisk";

                    // forward to the mega asterisk the represntation of the return value (&var / malloc / ptr)
                    megaAsterisk.GetComponent<IRepresentable>().setRepresentation(representation);

                    // set ticket to be child of mega asterisk
                    ticket.transform.parent = megaAsterisk.transform;

                    // set ticket infront of the mega asterisk
                    ticket.transform.localPosition = new Vector3(0, -0.15f, -1);

                    // remove box collider from ticket
                    Destroy(ticket.GetComponent<BoxCollider>());

                    // update logger
                    CodeLogger codeLogger = GameObject.Find("CodeLogger").GetComponent<CodeLogger>();
                    string loggerExtra = codeLogger.GetExtra();
                    codeLogger.SetExtra("*" + loggerExtra);
                }
            }

            Destroy(go);
            return;
        }

        // if the return value is int or pointer
        foreach (Transform child in transform)
        {
            if(!( child.gameObject==go) )// dont erase value if it is dragged from the return value and than released again on the return value
                Destroy(child.gameObject);// erase previous children
        }
        go.transform.parent = transform;

        //get the representation of the object landed (int / ticket)
        representation = go.GetComponent<IRepresentable>().getRepresentation();

        // check if level finished
        GameObject gameManagerGameObject = GameObject.Find("GameManager");
        GameManager gameManager = gameManagerGameObject.GetComponent<GameManager>();
        gameManager.CheckLevelComplete();
    }

}
