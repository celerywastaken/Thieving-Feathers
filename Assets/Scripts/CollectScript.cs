using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectScript : MonoBehaviour
{
    private PlayerMovement player;
    [SerializeField] private Transform pickUpTransform;

    public bool hasCollectable;

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
            Debug.Log("collided with collectable");
            player.CollectItem(other.transform);
            hasCollectable = true;
        }

    }

    





}
