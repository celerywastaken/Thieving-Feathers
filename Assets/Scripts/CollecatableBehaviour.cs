using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecatableBehaviour : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private CollectScript collectScript;
    [SerializeField] private PlayerMovement playerMovement;

    [SerializeField]private int pointValue; 

    [SerializeField] private Collectables collectableType;
 
    void Start()
    {
        //Gets a hold of the CollectSCript from the CollectTransform
        collectScript = GameObject.Find("CollectTransform").GetComponent<CollectScript>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();  
    }
     public Collectables GetCollectableType() { return collectableType; }
   
    void Update()
    {
        
    }
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.CompareTag("Nest"))
    //    {
    //        transform.SetParent(playerMovement.collectableOwnerTransform);
    //        transform.position = playerMovement.collectablePosition;
    //        // Destroy(gameObject);

    //        //Sets the hasCollectable bool to false, so we may pick up another Item.
    //        collectScript.hasCollectable = false;
    //        //Updates the Score 
    //        uiManager.UpdateScore(pointValue);
    //    }
    //}
}
