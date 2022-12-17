using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILandingArea 
{
    public bool OnDraggableReleased(GameObject go);
    public void OnLandingArea(GameObject go);

}
