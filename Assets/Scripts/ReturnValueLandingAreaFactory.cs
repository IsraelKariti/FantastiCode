using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnValueLandingAreaFactory : ReturnValueLandingArea
{
    private void Start()
    {
        LoadMegaAsteriskPrefab();
    }

    protected override void RescaleAndRepositionMegaAsteriskAndTicket()
    {
        // leave mega asterisk as it is
        megaAsteriskDup.transform.localScale = new Vector3(0.5f, 0.5f, 1f);

        // set ticket infront of the mega asterisk
        //ticket.transform.localPosition = new Vector3(0, -0.15f, -1);
        //ticket.transform.localScale = new Vector3(ticket.transform.localScale.x, ticket.transform.localScale.y, ticket.transform.localScale.z);
    }
}
