using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]

public class BoxClosedInt : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        Sprite s = Resources.Load<Sprite>("Sprites/fantasticodeclosedBox");

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = s;
        spriteRenderer.color = new Color(1f, 0.9f, 0.9f, 1f);
        transform.localScale = new Vector3(0.2f, 0.2f, 1f);
    }

}
