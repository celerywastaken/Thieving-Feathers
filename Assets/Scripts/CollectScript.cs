using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectScript : MonoBehaviour
{
    private PlayerMovement player;
    [SerializeField] private Transform pickUpTransform;

    private CollecatableBehaviour pickedUpCollectableBehaviour = null;

    public bool hasCollectable;
    public CollecatableBehaviour GetPickedUpCollectableBehaviour() { return pickedUpCollectableBehaviour; }
    void Start()
    {
        player = GetComponentInParent<PlayerMovement>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable") && !hasCollectable) 
        {   
            hasCollectable = true;
            pickedUpCollectableBehaviour = other.GetComponent<CollecatableBehaviour>();
            player.SetCollectable(pickedUpCollectableBehaviour.GetCollectableType());

            other.gameObject.SetActive(false); //make collectables go off
        }

    }

    





}
