using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableButton :MonoBehaviour, IPressable
{
    public GameObject closedBox;
    public GameObject openBox;
    public GameObject landingArea;

    private bool isOpen = false;
    private bool isClosed = true;

    public void OnPressed()
    {
        Debug.Log("pressed!");

        isOpen = !isOpen;

        // 
        isClosed = !isClosed;

        Debug.Log("isClosed after flip: " + isClosed);

        closedBox.SetActive(isClosed);
        openBox.SetActive(isOpen);
        landingArea.SetActive(isOpen);
    }
}
