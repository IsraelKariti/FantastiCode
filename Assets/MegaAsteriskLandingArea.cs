using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaAsteriskLandingArea : MonoBehaviour, ILandingArea
{
    public bool OnDraggableReleased(GameObject go)
    {
        MegaAsteriskOperator megaAsteriskOperator = go.GetComponent<MegaAsteriskOperator>();
        if (megaAsteriskOperator != null)
            return true;
        else
            return false;
    }

    public void OnLandingArea(GameObject go)
    {
        // open the box
        transform.parent.Find("OpenBox").gameObject.SetActive(true);
        transform.parent.Find("ClosedBox").gameObject.SetActive(false);

        Destroy(go);
    }

}
