using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MegaAsteriskLandingArea : MonoBehaviour, ILandingArea
{
    string currAddress;
    private void Start()
    {
        // get the address of this box
        Transform parent = transform.parent;
       
        currAddress = parent.Find("Ticket/Text (TMP)").gameObject.GetComponent<TMP_Text>().text;
        
        //Debug.Log("" + currAddress);
    }
    public virtual bool OnDraggableReleased(GameObject go)
    {
        MegaAsteriskOperator megaAsteriskOperator = go.GetComponent<MegaAsteriskOperator>();
        if (megaAsteriskOperator != null)
        {
            //get the address on the mega asterisk
            string megaAsteriskText = ExtractTextFromMegaAsterisk(go);
            if (currAddress.Equals(megaAsteriskText))
                return true;
            else
                return false;
        
        }
        else
            return false;
    }

    public virtual void OnLandingArea(GameObject go)
    {
        // open the box
        transform.parent.Find("BoxOpen").gameObject.SetActive(true);
        transform.parent.Find("BoxClosed").gameObject.SetActive(false);

        // get the address representaion (ptr1 / malloc / &var1)
        string addressRepresentaion = go.GetComponent<IRepresentable>().getRepresentation();

        transform.parent.GetComponent<IRepresentable>().setRepresentation("*" + addressRepresentaion);

        // destroy the mega asterisk
        Destroy(go);

        // check if the level is complete
        GameObject.Find("GameManager").GetComponent<GameManager>().CheckLevelComplete();
    }

    private string ExtractTextFromMegaAsterisk(GameObject go)
    {
        // get the ticket
        Transform ticketTransform = go.transform.Find("Ticket");

        // get the address from the ticket
        Transform ticketTextTransform = ticketTransform.Find("Text (TMP)");

        string ticketText = ticketTextTransform.GetComponent<TMP_Text>().text;

        return ticketText;
    }

}
