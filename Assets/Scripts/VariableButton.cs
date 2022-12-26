using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VariableButton :MonoBehaviour, IPressable
{
    public GameObject closedBox;
    public GameObject openBox;
    public GameObject landingArea;

    private bool isOpen = false;

    public void OnPressed()
    {
        isOpen = !isOpen;

        closedBox.SetActive(!isOpen);
        openBox.SetActive(isOpen);
        landingArea.SetActive(isOpen);

        // when a box is opening set the representaion (how it was opened)
        if (isOpen)
        {
            // get var name
            string varName = transform.Find("Text").GetComponent<TMP_Text>().text;

            // set representation in the container variable
            transform.parent.GetComponent<IRepresentable>().setRepresentation(varName);

            // let it know that it was opened by button
            Transform intValueTransform = transform.parent.Find("BoxOpen/LandingArea/IntVal");
            if (intValueTransform != null)
            {
                // set representation in the actual value
                GameObject intValGameObject = intValueTransform.gameObject;
                intValGameObject.GetComponent<IRepresentable>().setRepresentation(varName);
            }

            Transform ticketValueTransform = transform.parent.Find("BoxOpen/LandingArea/Ticket");
            if (ticketValueTransform != null)
            {
                // set representation in the actual value
                GameObject ticketValGameObject = ticketValueTransform.gameObject;
                ticketValGameObject.GetComponent<IRepresentable>().setRepresentation(varName);
            }
        }
    }
}
