using UnityEngine;

internal interface IDraggable
{
    public GameObject OnDragged();
    void OnRejectedFromLandingArea();

    public bool CheckIfPositionLegal(Vector3 pos);
}