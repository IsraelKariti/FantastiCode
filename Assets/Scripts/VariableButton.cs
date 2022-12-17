using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableButton :MonoBehaviour, Pressable
{
    public void OnPressed()
    {
        Debug.Log("pressed!");
    }
}
