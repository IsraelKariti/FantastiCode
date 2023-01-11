using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreen : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        if (Screen.fullScreen)
            Debug.Log("full");
        else
            Debug.Log("part");
    }
}
