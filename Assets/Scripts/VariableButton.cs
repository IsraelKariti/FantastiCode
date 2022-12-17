using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableButton :MonoBehaviour, Pressable
{
    public GameObject closedBox;
    public GameObject openBox;

    private bool isOpen = false;
    private bool isClosed = true;

    public void OnPressed()
    {
        Debug.Log("pressed!");

        isOpen = !isOpen;

        // 
        isClosed = !isClosed;

        Debug.Log("isClosed after flip: " + isClosed);

        closedBox.gameObject.SetActive(isClosed);
        openBox.gameObject.SetActive(isOpen);

    }
}
