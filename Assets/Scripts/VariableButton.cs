using System.Collections;
using System.Collections.Generic;
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

        // let in know that it was opened by button
        Transform intValueTransform = transform.parent.Find("BoxOpen/LandingArea/IntVal");
        if(intValueTransform != null)
        {
            GameObject intValGameObject = intValueTransform.gameObject;
            intValGameObject.GetComponent<IntVal>().openedByVariableButton = isOpen;

        }
    }
}
