using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableIntButtonFactory : VariableButton
{
    // Start is called before the first frame update
    void Start()
    {
        GetReferences();

        // set the sprite
        Transform buttonBackground = transform.Find("ButtonBackground");
        SpriteRenderer backgroundSpriteRenderer = buttonBackground.gameObject.GetComponent<SpriteRenderer>();
        backgroundSpriteRenderer.sprite = Resources.Load<Sprite>("Sprites/fantasticodeButtonRound");
        buttonBackground.localScale = new Vector3(0.4f, 0.3f, 1f);
    }

}
