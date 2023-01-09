using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class VariableIntButton : VariableButton
{
    // Start is called before the first frame update
    void Awake()
    {
        GetReferences();

        // set the sprite
        Transform buttonBackground = transform.Find("ButtonBackground");
        SpriteRenderer backgroundSpriteRenderer = buttonBackground.gameObject.GetComponent<SpriteRenderer>();
        backgroundSpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/fantasticodeButtonRound");
        buttonBackground.localScale = new Vector3(0.7f, 0.5f, 1f);
        //Debug.Log("scale: " + buttonBackground.localScale);
    }

   
}
