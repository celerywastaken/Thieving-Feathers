using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectScript : MonoBehaviour
{
    private PlayerMovement player;
    [SerializeField] private Transform pickUpTransform;
    
    void Start()
    {
        player = GetComponentInParent<PlayerMovement>();
    }

    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Collectable")) 
        { player.CollectItem(other.transform); }
    }

      
}
