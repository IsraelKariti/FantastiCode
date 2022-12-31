using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
public class GameManager : MonoBehaviour
{
    public GameObject goodWork;

    // called first
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // called second
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        int index = scene.buildIndex;
    }

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
            case 7:
                CheckLevelComplete7();
                return;
            case 8:
                CheckLevelComplete8();
                return;
            case 9:
                CheckLevelComplete9();
                return;

        }
    }


    private void CheckLevelComplete0()
    {
        // get int 2
        GameObject var = GameObject.Find("IntVariable2");
        GameObject go = var.transform.Find("BoxOpen/LandingArea/IntVal/ValText")?.gameObject;
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
        GameObject var = GameObject.Find("ReturnValue");
        GameObject go = var.transform.Find("LandingArea/IntVal/ValText")?.gameObject;
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
        GameObject var = GameObject.Find("ReturnValue");
        GameObject go = var.transform.Find("LandingArea/Ticket/Text (TMP)")?.gameObject;

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
        GameObject var = GameObject.Find("PointerVariable");
        GameObject go = var.transform.Find("BoxOpen/LandingArea/Ticket/Text (TMP)")?.gameObject;

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
        GameObject var1 = GameObject.Find("IntVariable1");
        GameObject var3 = GameObject.Find("IntVariable3");

        GameObject go1 = var1.transform.Find("BoxOpen/LandingArea/IntVal/ValText")?.gameObject;
        GameObject go3 = var3.transform.Find("BoxOpen/LandingArea/IntVal/ValText")?.gameObject;
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
        MegaAsteriskOperator[] objects = FindObjectsOfType<MegaAsteriskOperator>();
        // get int 2
        if(objects.Length == 1)
            Success();
    }
    private void CheckLevelComplete7()
    {
        // get int 2
        GameObject var4 = GameObject.Find("IntVariable4");
        GameObject go4 = var4.transform.Find("BoxOpen")?.gameObject;

        if (go4.activeSelf)
            Success();

    }
    private void CheckLevelComplete8()
    {
        // get int 2
        GameObject var1 = GameObject.Find("IntVariable1");
        GameObject var3 = GameObject.Find("IntVariable3");

        GameObject go1 = var1.transform.Find("BoxOpen/LandingArea/IntVal/ValText")?.gameObject;
        GameObject go3 = var3.transform.Find("BoxOpen/LandingArea/IntVal/ValText")?.gameObject;

        if (go1 == null || go3 == null)
            return;

        // get the int value
        string val1 = go1.GetComponent<TMP_Text>().text;
        string val3 = go3.GetComponent<TMP_Text>().text;

        if (val1.Equals("555") && val3.Equals("142"))
        {
            Success();
        }
    }

    private void CheckLevelComplete9()
    {
        throw new NotImplementedException();
    }
    private void Success()
    {
        Debug.Log("success");
        goodWork.SetActive(true);
    }
}
