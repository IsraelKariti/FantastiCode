using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject goodWork;

    public void CheckLevelComplete()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        switch (sceneIndex)
        {
            case 0:
                CheckLevelComplete0();
                return ;
            case 1:
                CheckLevelComplete1();
                return;
            case 2:
                CheckLevelComplete2();
                return;
            case 3:
                CheckLevelComplete3();
                return;
            case 4:
                CheckLevelComplete4();
                return;
            case 5:
                CheckLevelComplete5();
                return;
            case 6:
                CheckLevelComplete6();
                return;

        }
    }

    private void CheckLevelComplete0()
    {
        // get int 2
        GameObject go = GameObject.Find("IntVariable2/BoxOpen/LandingArea/IntVal/ValText");
        if (go == null)
            return;
        // get the int value
        string val = go.GetComponent<TMP_Text>().text;

        if (val.Equals("142") ==  true) {
            Success();
        }
    }
    private void CheckLevelComplete1()
    {
        // get int 2
        GameObject go = GameObject.Find("ReturnValue/LandingArea/IntVal/ValText");
        if (go == null)
            return;
        // get the int value
        string val = go.GetComponent<TMP_Text>().text;

        if (val.Equals("555")) {
            Success();
        }
    }
    private void CheckLevelComplete2()
    {
        // get int 2
        GameObject go = GameObject.Find("ReturnValue/LandingArea/Ticket/Text (TMP)");

        if (go == null)
            return;

        // get the int value
        string val = go.GetComponent<TMP_Text>().text;

        if (val.Equals("BF53")) {
            Success();
        }
    }
    private void CheckLevelComplete3()
    {
        // get int 2
        GameObject go = GameObject.Find("ReturnValue/LandingArea/Ticket/Text (TMP)");
        if (go == null)
            return;
        // get the int value
        string val = go.GetComponent<TMP_Text>().text;

        if (val.Equals("BF54")) {
            Success();
        }
    }
    private void CheckLevelComplete4()
    {
        // get int 2
        GameObject go = GameObject.Find("PointerVariable/BoxOpen/LandingArea/Ticket/Text (TMP)");

        if (go == null)
            return;

        // get the int value
        string val = go.GetComponent<TMP_Text>().text;

        if (val.Equals("BF54")) {
            Success();
        }
    }
    private void CheckLevelComplete5()
    {
        // get int 2
        GameObject go1 = GameObject.Find("IntVariable1/BoxOpen/LandingArea/IntVal/ValText");
        GameObject go3 = GameObject.Find("IntVariable3/BoxOpen/LandingArea/IntVal/ValText");

        if (go1 == null || go3 == null)
            return;

        // get the int value
        string val1 = go1.GetComponent<TMP_Text>().text;
        string val3 = go3.GetComponent<TMP_Text>().text;

        if (val1.Equals("555") && val3.Equals("142")) {
            Success();
        }
    }
    private void CheckLevelComplete6()
    {
        // get int 2
        GameObject go1 = GameObject.Find("IntVariable1/BoxOpen/LandingArea/IntVal/ValText");
        GameObject go3 = GameObject.Find("IntVariable3/BoxOpen/LandingArea/IntVal/ValText");
        
        if (go1 == null || go3 == null)
            return;
        
        // get the int value
        string val1 = go1.GetComponent<TMP_Text>().text;
        string val3 = go3.GetComponent<TMP_Text>().text;

        if (val1.Equals("555") && val3.Equals("142")) {
            Success();
        }
    }

    private void Success()
    {
        Debug.Log("success");
        goodWork.SetActive(true);
    }
}
