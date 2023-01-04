using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmpersandLandingAreaFactory : AmpersandLandingArea
{
    protected override Transform GetReturnValueLandingAreaTransform()
    {
        return transform.parent.parent.parent.Find("ReturnValue/LandingArea");
    }

    protected override CodeLogger GetCodeLogger()
    {
        return transform.parent.parent.parent.Find("CodeLogger").GetComponent<CodeLogger>();
    }
}
