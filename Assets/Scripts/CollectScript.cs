using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectScript : MonoBehaviour
{
    private PlayerMovement player;
    [SerializeField] private Transform pickUpTransform;

    private Collectables pickedUpCollectable = Collectables.None;

    public bool hasCollectable;
    public Collectables GetPickedUpCollectable() { return pickedUpCollectable; }
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
           pickedUpCollectable = other.GetComponent<CollecatableBehaviour>().GetCollectableType();
            player.SetCollectable(pickedUpCollectable);
        }

    }

    





}
