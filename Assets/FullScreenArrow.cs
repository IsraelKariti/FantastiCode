using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenArrow : MonoBehaviour
{
    
    
    // Update is called once per frame
    void Update()
    {
        float y = Mathf.Sin(4*Time.time);
        transform.localPosition = new Vector3(0, y, 0);
    }
}
