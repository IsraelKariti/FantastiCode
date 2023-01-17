using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Seperator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.localPosition = new Vector3(4f, -1f, 0);
        transform.localScale = new Vector3(12f, 0.1f, 1);
    }

}
