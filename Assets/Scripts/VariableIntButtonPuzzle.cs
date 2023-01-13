using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class VariableIntButtonPuzzle : VariableButton
{
    // Start is called before the first frame update
    void Awake()
    {
        GetReferences();

        // set the spritef
        Transform buttonBackground = transform.Find("ButtonBackground");
        SpriteRenderer backgroundSpriteRenderer = buttonBackground.gameObject.GetComponent<SpriteRenderer>();
        backgroundSpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/fantasticodeButtonPuzzle");
        buttonBackground.localScale = new Vector3(0.5f, 0.4f, 1f);
        buttonBackground.localPosition = new Vector3(-0.35f, 0, 0);
        //Debug.Log("scale: " + buttonBackground.localScale);
    }
}
