using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface PositionLegalityChecker
{
    public bool CheckIfPositionLegal(GameObject val, Vector3 pos);
}

// this is for the case when the value is inside the factory, ex: return value \ input and CANNOT be dragged outside
public class CheckPositionWhenValDestinedToSelfFactory : MonoBehaviour, PositionLegalityChecker
{
    bool PositionLegalityChecker.CheckIfPositionLegal(GameObject val, Vector3 pos)
    {
        // access both factories
        Factory factory1 = GameObject.Find("Factory1").GetComponent<Factory>();
        Factory factory2 = GameObject.Find("Factory2").GetComponent<Factory>();

        // access the local factory
        Factory localFactory = val.transform.parent.parent.parent.GetComponent<Factory>();

        Factory oponnentFactory = null;
        if (localFactory == factory1)
            oponnentFactory = factory2;
        else
            oponnentFactory = factory1;




        // access the factory
        Bounds opponentFactoryBounds = oponnentFactory.transform.Find("FactoryBackground").GetComponent<SpriteRenderer>().bounds;

        Vector3 max = opponentFactoryBounds.max;
        Vector3 min = opponentFactoryBounds.min;

        // if the position is inside the opponnet factory return false
        if (pos.x > min.x && pos.x < max.x && pos.y > min.y && pos.y < max.y)
            return false;
        else
            return true;
    }
}

// if the val is opened by tools in its factory than it cannot be dragged into other factory
public class CheckPositionWhenValIsInBoxOpenedBySelfFactory : MonoBehaviour, PositionLegalityChecker
{
    bool PositionLegalityChecker.CheckIfPositionLegal(GameObject val, Vector3 pos)
    {
        return true;
    }
}


