using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClosedFactory : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sprite s = Resources.Load<Sprite>("Sprites/fantasticodeclosedBox");

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = s;

        transform.localScale = new Vector3(0.1f, 0.1f, 1f);
    }
}
