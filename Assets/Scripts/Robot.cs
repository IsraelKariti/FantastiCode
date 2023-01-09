using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Robot : MonoBehaviour, IDraggable
{

    private void Awake()
    {
        transform.localPosition = new Vector3(-9f, 3.74f, -5f);

        // load robot sprite
        Transform transformRobotBackground = transform.Find("RobotBackground");
        SpriteRenderer sr = transformRobotBackground.GetComponent<SpriteRenderer>();

        // get the sprite of the robot
        Sprite s = Resources.Load<Sprite>("Sprites/fantasticodeRobotShort");

        sr.sprite = s;

        transformRobotBackground.localScale = new Vector3(0.2f, 0.25f, 1f);
    }


    public virtual bool CheckIfPositionLegal(Vector3 pos)
    {
        return true;
    }

    public virtual GameObject OnDragged()
    {
        GameObject go = Instantiate(gameObject, transform.position, transform.rotation);
        go.name = "Robot";

        return go;
    }
    
    public virtual void OnRejectedFromLandingArea()
    {
        Destroy(gameObject); 
    }

}
