using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaAsteriskLandingAreaFactory : MegaAsteriskLandingArea
{
    public override void OnLandingArea(GameObject megaAsterisk)
    {
        // find the factory of the mega asterisk


        // open the box
        transform.parent.Find("BoxOpen").gameObject.SetActive(true);
        transform.parent.Find("BoxClosed").gameObject.SetActive(false);

        // duplicate value

        // animate int to return value

        //close the box
        transform.parent.Find("BoxOpen").gameObject.SetActive(false);
        transform.parent.Find("BoxClosed").gameObject.SetActive(true);

        // get the address representaion (ptr1 / malloc / &var1)
        string addressRepresentaion = megaAsterisk.GetComponent<IRepresentable>().getRepresentation();

        transform.parent.GetComponent<IRepresentable>().setRepresentation("*" + addressRepresentaion);

        // destroy the mega asterisk
        Destroy(megaAsterisk);

        // check if the level is complete
        GameObject.Find("GameManager").GetComponent<GameManager>().CheckLevelComplete();
    }
}
