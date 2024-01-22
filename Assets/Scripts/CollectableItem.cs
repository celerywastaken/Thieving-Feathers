using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField] private Collectables collectableType;
    // Start is called before the first frame update

    public Collectables GetCollectableType()
    {
        return collectableType;
    }
}
