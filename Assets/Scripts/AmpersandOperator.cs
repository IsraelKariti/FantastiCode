using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class AmpersandOperator : MonoBehaviour, IDraggable
{
    private void Start()
    {
        Transform backgroundTransform = transform.Find("AmpersandBackground");
        SpriteRenderer spriteRenderer = backgroundTransform.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = Resources.Load<Sprite>("Sprites/fantasticodeAmpersandPuzzle");
        backgroundTransform.localScale = new Vector3(0.5f, 0.4f, 1);
    }
    public virtual bool CheckIfPositionLegal(Vector3 pos)
    {
            return true;
    }

    public virtual GameObject OnDragged()
    {
        GameObject go = Instantiate(gameObject, transform.position, transform.rotation);
        go.name = "Ampersand";
        return go;
    }
    public virtual void OnRejectedFromLandingArea()
    {
        Destroy(gameObject);
    }


}