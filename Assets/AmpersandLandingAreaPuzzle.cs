using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class AmpersandLandingAreaPuzzle : AmpersandLandingArea
{
    private void Start()
    {
        // get current variable name
        varName = transform.parent.Find("Button/Text").GetComponent<TMP_Text>().text;

        // set the position and size of the collider
        BoxCollider boxCollider = GetComponent<BoxCollider>();
        boxCollider.center = new Vector3(-3f, 0, 0);
        boxCollider.size = new Vector3(3f, 2.5f, 1);
    }

    public override void OnLandingArea(GameObject ampersand)
    {
        // make ampersand child of landing area
        ampersand.transform.parent = transform;

        // make ampersand puzzle tuck into button puzzle 
        ampersand.transform.localPosition = new Vector3(-2.63f, 0, -1f);

        StartCoroutine(CaptureAddressInsertToReturnValue(ampersand));

        // update code logger
        CodeLogger codeLogger = GetCodeLogger();// 
        codeLogger.SetExtra("&" + varName);
    }
}
