using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecatableBehaviour : CollectableItem
{

    [SerializeField]private int pointValue; 

    public int GetPointValue()
    {
        return pointValue;
    }
   

}
