using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duplicable : MonoBehaviour
{
    public GameObject toDuplicate;

    internal GameObject CreateDuplicate()
    {
        GameObject dup = Instantiate(toDuplicate);
        return dup;
    }
}
