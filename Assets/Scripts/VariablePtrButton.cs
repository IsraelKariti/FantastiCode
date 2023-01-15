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
        buttonBackground.localScale = new Vector3(0.55f, 0.5f, 1f);
        //Debug.Log("scale: " + buttonBackground.localScale);

        // destroy all previous colliders
        foreach (Collider col in GetComponents<Collider>())
            DestroyImmediate(col);

        CapsuleCollider capCol = gameObject.AddComponent<CapsuleCollider>();
        capCol.radius = 0.71f;
        capCol.height = 2.47f;
        capCol.center = new Vector3(0, 0.2f, 0);
        capCol.direction = 0;

        // set the position of the text
        Transform textTransform = transform.Find("Text");
        textTransform.localPosition = new Vector3(0, 0.4f, 0);
    }


}
