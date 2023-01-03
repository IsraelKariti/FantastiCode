using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaAsteriskLandingAreaFactory : MegaAsteriskLandingArea
{
    public override void OnLandingArea(GameObject megaAsterisk)
    {
        StartCoroutine(OnLandingAreaAnimation(megaAsterisk));
    }

    private IEnumerator OnLandingAreaAnimation(GameObject megaAsterisk)
    {
        // set the address representaion (ptr1 / malloc / &var1)
        string addressRepresentaion = megaAsterisk.GetComponent<IRepresentable>().getRepresentation();
        transform.parent.GetComponent<IRepresentable>().setRepresentation("*" + addressRepresentaion);

        // find the return value of the factory of the mega asterisk 
        // this will be the destination of the value
        Factory factory = megaAsterisk.transform.parent.parent.parent.GetComponent<Factory>();
        Transform returnValueTransform = factory.transform.Find("ReturnValue/LandingArea");

        // open the box
        transform.parent.Find("BoxOpen").gameObject.SetActive(true);
        transform.parent.Find("BoxClosed").gameObject.SetActive(false);

        // duplicate value and set it as a child of the destination return value
        GameObject goVal = transform.parent.Find("BoxOpen/LandingArea/IntVal").gameObject;
        GameObject dup = Instantiate(goVal, goVal.transform.position, goVal.transform.rotation, returnValueTransform);

        // animate int to return value
        yield return SendToReturnValue(dup.transform);

        //close the box
        transform.parent.Find("BoxOpen").gameObject.SetActive(false);
        transform.parent.Find("BoxClosed").gameObject.SetActive(true);

        // destroy the mega asterisk
        Destroy(megaAsterisk);

        // check if the level is complete
        GameObject.Find("GameManager").GetComponent<GameManager>().CheckLevelComplete();
    }
   
    private IEnumerator SendToReturnValue(Transform val)
    {
        float timePassed = 0;

        Vector3 startLocalPos = val.localPosition;
        Vector3 endLocalPos = new Vector3(0f, 0, 0);

        float fraction = 0;
        float animTime = 1f;

        while (fraction < 1)
        {
            timePassed += Time.deltaTime;
            fraction = timePassed / animTime;

            val.localPosition = Vector3.Lerp(startLocalPos, endLocalPos, fraction);
            yield return null;
        }

        // destroy all children on return value
    }
}
