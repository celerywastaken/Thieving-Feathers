using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectScript : MonoBehaviour
{
    private PlayerMovement player;                       // Reference to the PlayerMovement script
    [SerializeField] private Transform pickUpTransform; // Reference to the pick-up transform

    public bool hasCollectable;                       // Indicates if the player has a collectible item

    void Start()
    {
        // Gets a reference to the PlayerMovement script from the parent GameObject
        player = GetComponentInParent<PlayerMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider's tag is "Collectable" and the player doesn't already have a collectible
        if (other.CompareTag("Collectable") && !hasCollectable)
        {
            // Instructs the player to collect the item and passes the transform of the collectable
            player.CollectItem(other.transform);

            // Set hasCollectable to true, indicating the player has a collectible
            hasCollectable = true;
        }

    }

}
