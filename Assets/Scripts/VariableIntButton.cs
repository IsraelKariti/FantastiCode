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

      // destroy all previous colliders
        foreach(Collider col in GetComponents<Collider>())  
            DestroyImmediate(col);

        // set collider of button to sphere
        // check if capsule collider exists
        CapsuleCollider capsuleCollider = gameObject.GetComponent<CapsuleCollider>();
        if (capsuleCollider == null)
        {

            CapsuleCollider capCol = gameObject.AddComponent<CapsuleCollider>();
            capCol.radius = 0.71f;
            capCol.height = 2.47f;
            capCol.center = new Vector3(0, 0.2f, 0);
            capCol.direction = 0;
        }
    }

   
}
