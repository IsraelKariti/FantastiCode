using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using Unity.Services.Core;
using Unity.Services.Analytics;
using Unity.Services.Core.Environments;
public class GameManager : MonoBehaviour
{
    public GameObject goodWork;
    string consentIdentifier;
    bool isOptInConsentRequired;

    async void Start()
    {

        try
        {
            await UnityServices.InitializeAsync();
            //List<string> consentIdentifiers = await AnalyticsService.Instance.CheckForRequiredConsents();
            List<string> consentIdentifiers = await Events.CheckForRequiredConsents();
            if (consentIdentifiers.Count > 0)
            {
                consentIdentifier = consentIdentifiers[0];
                isOptInConsentRequired = consentIdentifier == "pipl";
            }
            if (isOptInConsentRequired)
            {
                Events.ProvideOptInConsent(consentIdentifier, false);
            }
        }
        catch (ConsentCheckException e)
        {
            // Something went wrong when checking the GeoIP, check the e.Reason and handle appropriately.
        }
        int buildIndex = SceneManager.GetActiveScene().buildIndex;
        Dictionary<string, object> parameters = new Dictionary<string, object>()
        {
            { "levelStarted", buildIndex }
        };
        // The ‘myEvent’ event will get queued up and sent every minute
       AnalyticsService.Instance.CustomData("myEvent", parameters);
       //Events.CustomData("myEvent", parameters);

        // Optional - You can call Events.Flush() to send the event immediately
        //AnalyticsService.Instance.Flush();
        Events.Flush();


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
            case 10:
                CheckLevelComplete10();
                return;
            case 11:
                CheckLevelComplete11();
                return;
            case 12:
                CheckLevelComplete12();
                return;

        }
    }

    private void CheckLevelComplete0()
    {
        GameObject var = GameObject.Find("IntVariable1");
        GameObject go = var.transform.Find("BoxOpen/LandingArea/IntVal/ValText")?.gameObject;
        if (go == null)
            return;

        Success();
    }

    private void CheckLevelComplete1()
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
    private void CheckLevelComplete2()
    {
        GameObject[] gos = new GameObject[3];
        List<string> strings = new List<string>();
        // get int 2
        gos[0] = GameObject.Find("IntVariable1");
        gos[1] = GameObject.Find("IntVariable2");
        gos[2] = GameObject.Find("IntVariable3");

        foreach(GameObject go in gos)
        {
            Transform t = go.transform.Find("BoxOpen/LandingArea/IntVal/ValText");
            // if the box has a number take it for comparison
            if (t != null)
            {
                strings.Add(t.gameObject.GetComponent<TMP_Text>().text);
            }
        }

        // check if all the numbers are the same
        string help = strings.ElementAt(0);

        bool flagDiff = false;

        foreach(string str in strings)
        {
            if (str.Equals(help) == false)
                flagDiff = true;
        }

        // check if all numbers are equal
        if(flagDiff == false)
        {
            GameObject goReset = GameObject.Find("ResetExplanation");
            GameObject goTxt = goReset.transform.Find("Text").gameObject;
            
            if(goTxt.activeSelf == false)
                goTxt.SetActive(true);
        }

        // if the numbers are not equal that means that there is a chance of success
        GameObject go1 = gos[0].transform.Find("BoxOpen/LandingArea/IntVal/ValText")?.gameObject;
        GameObject go3 = gos[2].transform.Find("BoxOpen/LandingArea/IntVal/ValText")?.gameObject;
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

    private void CheckLevelComplete3()
    {


        /////////
        /// // get int 2
        GameObject v = GameObject.Find("ReturnValue");
        GameObject go = v.transform.Find("LandingArea/IntVal/ValText")?.gameObject;
        if (go == null)
            return;
        // get the int value
        string val = go.GetComponent<TMP_Text>().text;

        if (val.Equals("555"))
        {
            Success();
        }
    }
    private void CheckLevelComplete4()
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
    private void CheckLevelComplete5()
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
    private void CheckLevelComplete6()
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
    
   
    private void CheckLevelComplete7()
    {
        MegaAsteriskOperator[] objects = FindObjectsOfType<MegaAsteriskOperator>();
        // get int 2
        if(objects.Length == 1)
            Success();
    }
    private void CheckLevelComplete8()
    {
        // get int 2
        GameObject var4 = GameObject.Find("IntVariable4");
        GameObject go4 = var4.transform.Find("BoxOpen")?.gameObject;

        if (go4.activeSelf)
            Success();

    }
    private void CheckLevelComplete9()
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

    private void CheckLevelComplete10()
    {
        GameObject factory1 = GameObject.Find("Factory2");
        Transform inputTransform = factory1.transform.Find("Input");
        Transform inputLandingArea = inputTransform.Find("LandingArea");
        if (inputLandingArea.childCount > 0)
            Success();
    }

    private void CheckLevelComplete11()
    {
        GameObject factory2 = GameObject.Find("Factory2");
        GameObject go3 = factory2.transform.Find("Variables/IntVariable3/BoxOpen/LandingArea/IntVal/ValText")?.gameObject;

        if (go3 == null)
            return;

        string val3 = go3.GetComponent<TMP_Text>().text;

        if (val3.Equals("989"))
        {
            Success();
        }
    }

    private void CheckLevelComplete12()
    {
        GameObject factory1 = GameObject.Find("Factory1");
        GameObject go1 = factory1.transform.Find("Variables/IntVariable1/BoxOpen/LandingArea/IntVal/ValText")?.gameObject;
        GameObject go3 = factory1.transform.Find("Variables/IntVariable3/BoxOpen/LandingArea/IntVal/ValText")?.gameObject;

        if (go1 == null || go3 == null)
            return;

        string val1 = go1.GetComponent<TMP_Text>().text;
        string val3 = go3.GetComponent<TMP_Text>().text;

        if (val1.Equals("704") && val3.Equals("311"))
        {
            Success();
        }
    }

    private void Success()
    {
        Debug.Log("success");
        goodWork.SetActive(true);
    }
}
