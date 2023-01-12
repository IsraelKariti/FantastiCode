using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FullScreenChecker : MonoBehaviour
{
    bool lastFrameFullScreen;

    private GameObject cam;
    void Start()
    {
        lastFrameFullScreen = true;
        cam = GameObject.Find("Main Camera");

    }
    private void Update()
    {
#if(UNITY_EDITOR)
        return;
#endif
        if (Screen.fullScreen == false)
        {
            // if this is the first frame that is NOT full screen
            if (lastFrameFullScreen == true)
            {
                lastFrameFullScreen = false;

                // rotate cam backwards
                cam.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }
            // every other frame that the game is not full screen
            // attempt to make game full screen
            Screen.fullScreen = true;
        }
        //tMP_Text.text = tMP_Text.text + "y";
        // if it was successfull 
        if (Screen.fullScreen)
        {
            lastFrameFullScreen = true;

            // rotate cam forward
            cam.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }

    }
}
