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
        endScale = startScale + new Vector3(.25f, 0, 0);

        startPos = lassoBackgroundTransfrom.position;
        endPos = startPos + new Vector3(3.9f, 0, 0);

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
