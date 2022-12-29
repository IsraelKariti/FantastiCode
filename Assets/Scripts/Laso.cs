using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laso : MonoBehaviour
{
    float animTime = 1f;

    Vector3 startScale;
    Vector3 endScale;

    Vector3 startPos;
    Vector3 endPos;

    
    public IEnumerator Fetch()
    {
        // extend the rope
        yield return StrechAnim();

        // duplicate address
        GameObject ticket = transform.parent.parent.parent.Find("Ticket").gameObject;
        GameObject dup = Instantiate(ticket, ticket.transform.position, ticket.transform.rotation, transform);
        dup.name = "Ticket";

        // draw address back
        yield return UnStrechAnimWithTicket(dup);

        // change the ticket parent to the ampersand landing area
        dup.transform.parent = transform.parent.parent;
    }

    private IEnumerator StrechAnim()
    {
        Transform lassoBackgroundTransfrom = transform.Find("LasoBackground");
        
        float timePassed = 0;

        startScale = lassoBackgroundTransfrom.localScale;
        endScale = startScale + CalculateLasoScaleX();

        startPos = lassoBackgroundTransfrom.position;
        endPos = startPos + CalculateLasoShiftX();

        float fraction = 0;

        while (fraction < 1)
        {
            timePassed += Time.deltaTime;
            fraction = timePassed / animTime;
            lassoBackgroundTransfrom.localScale = Vector3.Lerp(startScale, endScale, fraction);
            lassoBackgroundTransfrom.position = Vector3.Lerp(startPos, endPos, fraction);
            yield return null;
        }
    }

    // calculate how much the laso png need to be streched to reach the ticket
    // when the laso scale is 1 it will be of length 31 meters
    private Vector3 CalculateLasoScaleX()
    {
        // calculate the number of meters between laso center and ticket center
        float ticketCenter = transform.parent.parent.parent.Find("Ticket").position.x;
        float lassoCenter = transform.position.x;
        float diff = Math.Abs(ticketCenter - lassoCenter);
        float portion = diff / 31f;

        return new Vector3(portion, 0, 0);
    }
    
    // calculate how much the laso png need to be streched to reach the ticket
    // when the laso scale is 1 it will be of length 31 meters
    private Vector3 CalculateLasoShiftX()
    {
        // calculate the number of meters between laso center and ticket center
        float ticketCenter = transform.parent.parent.parent.Find("Ticket").position.x;
        float lassoCenter = transform.position.x;
        float diff = Math.Abs(ticketCenter - lassoCenter);
        float shift = diff / 2f;

        return new Vector3(shift, 0, 0);
    }

    private IEnumerator UnStrechAnimWithTicket(GameObject dup)
    {
        Transform lassoBackgroundTransfrom = transform.Find("LasoBackground");
        float timePassed = 0;

        float fraction = 0;

        Vector3 dupStartPos = dup.transform.localPosition;
        Vector3 dupEndPos = new Vector3(0, 0, 0);

        while (fraction < 1)
        {
            timePassed += Time.deltaTime;
            fraction = timePassed / animTime;
            lassoBackgroundTransfrom.localScale = Vector3.Lerp(endScale, startScale,  fraction);
            lassoBackgroundTransfrom.position = Vector3.Lerp(endPos, startPos, fraction);
            dup.transform.localPosition = Vector3.Lerp(dupStartPos, dupEndPos, fraction);
            yield return null;
        }
    }
}
