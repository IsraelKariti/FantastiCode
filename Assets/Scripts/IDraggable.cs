using UnityEngine;

internal interface IDraggable
{
    public GameObject OnDragged();
    void OnRejectedFromLandingArea();
}