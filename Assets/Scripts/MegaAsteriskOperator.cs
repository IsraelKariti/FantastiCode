using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaAsteriskOperator : MonoBehaviour, IDraggable
{
    Vector3 startPos;
    Transform[] transforms;
    int[] inCloudRadiuses;

    double innerRadius = 7;
    double outerRadius = 15;


    public GameObject OnDragged()
    {
        startPos = transform.position;
        return gameObject;
    }

    public void OnRejectedFromLandingArea()
    {
        transform.position = startPos;
    }

    private void OnDestroy()
    {
        for(int i = 0; i < transforms.Length; i++)
        {
            Transform currTransform = transforms[i];
            if (currTransform == null)
                continue;

            inCloudRadiuses[i] = 0;

            currTransform.GetComponent<Cloud>().DimCloud();
        }
    }

    private void Start()
    {
        // get all clouds' transforms
        transforms = new Transform[5];
        transforms[0] = GameObject.Find("IntVariable1/Cloud")?.transform;
        transforms[1] = GameObject.Find("IntVariable2/Cloud")?.transform;
        transforms[2] = GameObject.Find("IntVariable3/Cloud")?.transform;
        transforms[3] = GameObject.Find("IntVariable4/Cloud")?.transform;
        transforms[4] = GameObject.Find("PointerVariable/Cloud")?.transform;

        inCloudRadiuses = new int[5];
    }

    public void Update()
    {
        //check if there is a cloud in the radius
        for (int i = 0;i < transforms.Length;i++)
        {
            Transform currTransform = transforms[i];
            if (currTransform == null)
                continue;

            double dist = Vector3.SqrMagnitude(transform.position - currTransform.position);

            // enter outer circle
            if (inCloudRadiuses[i] == 0 && dist < outerRadius)
            {
                inCloudRadiuses[i] = 1;

                currTransform.GetComponent<Cloud>().HalfDim();

                continue;
            }

            // exit outer circle
            if (inCloudRadiuses[i] == 1 && dist > outerRadius)
            {
                inCloudRadiuses[i] = 0;

                currTransform.GetComponent<Cloud>().DimCloud();

                continue;
            }

            // endter inner circle
            if (inCloudRadiuses[i] == 1 && dist < innerRadius)
            {
                inCloudRadiuses[i] = 2;

                currTransform.GetComponent<Cloud>().Transparentize();

                continue;
            }

            // exit inner circle
            if (inCloudRadiuses[i] == 2 && dist > innerRadius)
            {
                inCloudRadiuses[i] = 1;

                currTransform.GetComponent<Cloud>().HalfDim();

                continue;
            }
        }


    }
}
