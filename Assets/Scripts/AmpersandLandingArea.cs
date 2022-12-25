using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmpersandLandingArea : MonoBehaviour, ILandingArea
{
    // check if the object that is being released on the landing area is supposed to be released there
    // for ex. address can't be released on an int
    public bool OnDraggableReleased(GameObject go)
    {
        // how do i check if the game object is an int???
        AmpersandOperator op = go.GetComponent<AmpersandOperator>();
        if (op != null)
            return true;
        else
            return false;
    }

    //once the object has been releaased
    public void OnLandingArea(GameObject go)
    {
        go.transform.parent = transform;

        StartCoroutine( CaptureAddressInsertToReturnValue(go));

        // update code logger
        // get current variable name
        string varName = transform.parent.Find("Button/Text").GetComponent<TMP_Text>().text;
        // log in code
        GameObject codeLoggerText = GameObject.Find("CodeLogger/Text (TMP)");
        TMP_Text tMP_Text = codeLoggerText.GetComponent<TMP_Text>();
        tMP_Text.text = tMP_Text.text + "\n&" + varName ;
    }

    private IEnumerator CaptureAddressInsertToReturnValue(GameObject go)
    {
        Laso laso = go.transform.Find("Laso").GetComponent<Laso>();

        // fetch the address by streching and shortening 
        yield return laso.Fetch();

        // destroy amperdand on landing area
        Destroy(transform.Find("Ampersand").gameObject);

        // delete all children of return value
        Transform returnValueLandingAreaTransform = GameObject.Find("ReturnValue/LandingArea").transform;
        foreach (Transform t in returnValueLandingAreaTransform)
            Destroy(t.gameObject);

        //change ticket to be the child of return value
        Transform ticketTransform = transform.Find("Ticket");
        ticketTransform.parent = returnValueLandingAreaTransform;

        // send the address to the return value
        yield return SendToReturnValue(ticketTransform);

        
    }

    private IEnumerator SendToReturnValue(Transform ticket)
    {
        float timePassed = 0;

        Vector3 startLocalPos = ticket.localPosition;
        Vector3 endLocalPos = new Vector3(0f, 0, 0);

        float fraction = 0;
        float animTime = 1f;

        while (fraction < 1)
        {
            timePassed += Time.deltaTime;
            fraction = timePassed / animTime;

            ticket.localPosition = Vector3.Lerp(startLocalPos, endLocalPos, fraction);
            yield return null;
        }

        // destroy all children on return value
    }

}
