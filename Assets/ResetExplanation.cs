using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResetExplanation : MonoBehaviour
{
    // Update is called once per frame
    void Start()
    {
        // make the explanation blink
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            TMP_Text t = GetComponent<TMP_Text>();
            t.enabled = !t.enabled;
        }
    }
}
