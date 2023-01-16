using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class VariablePtrButton : VariableButton
{
    // Start is called before the first frame update
    void Awake()
    {
        GetReferences();

        // set the sprite
        Transform buttonBackground = transform.Find("ButtonBackground");
        SpriteRenderer backgroundSpriteRenderer = buttonBackground.gameObject.GetComponent<SpriteRenderer>();
        backgroundSpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/fantasticodeButtonGreen");
        buttonBackground.localScale = new Vector3(0.5f, 0.4f, 1f);

        // reposition the text
        Transform textBackground = transform.Find("Text");
        textBackground.localPosition = new Vector3(0, 0.22f, 0);
        //Debug.Log("scale: " + buttonBackground.localScale);
    }


}
