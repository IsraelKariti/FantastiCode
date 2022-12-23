using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILandingArea 
{
    // check if the object that is being released on the landing area is supposed to be released there
    // for ex. address can't be released on an int
    public bool OnDraggableReleased(GameObject go);

    // the game object is being placed on the landing area
    public void OnLandingArea(GameObject go);

}
