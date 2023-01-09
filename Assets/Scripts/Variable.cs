using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class Variable : MonoBehaviour, IRepresentable
{
    private string representaion;

    private void Awake()
    {
        // set representation (this is only important if the box was already open when the scene loaded Ex. scene 1)
        string r = transform.Find("Button/Text").GetComponent<TMP_Text>().text;
        setRepresentation(r);

    }

    private void Start()
    {

        // disable the checkbox
        transform.Find("CheckBox").gameObject.SetActive(false);
    }

    public string getRepresentation()
    {
        return representaion;
    }

    public void setRepresentation(string r)
    {
        representaion = r;

        // set also on the actual value if exist
        Transform intValTransform = transform.Find("BoxOpen/LandingArea/IntVal");
        if (intValTransform != null)
        {
            IRepresentable representable = intValTransform.GetComponent<IRepresentable>();
            representable.setRepresentation(r);
        }
        // set also on the actual value if exist
        Transform ticketValTransform = transform.Find("BoxOpen/LandingArea/Ticket");
        if (ticketValTransform != null)
        {
            IRepresentable representable = ticketValTransform.GetComponent<IRepresentable>();
            representable.setRepresentation(r);
        }
    }
}
