using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    public void DimCloud()
    {
        SpriteRenderer spriteRenderer = transform.Find("CloudBackground").GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
    }
    public void HalfDim()
    {
        SpriteRenderer spriteRenderer = transform.Find("CloudBackground").GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.8f);
    }
    public void Transparentize()
    {

        SpriteRenderer spriteRenderer = transform.Find("CloudBackground").GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.3f);
    }
}
