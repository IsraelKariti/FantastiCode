using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Variable : MonoBehaviour, IRepresentable
{
    private string representaion;

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
    }
}
