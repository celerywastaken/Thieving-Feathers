using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecatableBehaviour : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    [SerializeField] private CollectScript collectScript;

    [SerializeField]private int pointValue;
 
    void Start()
    {
        //Gets a hold of the CollectSCript from the CollectTransform
        collectScript = GameObject.Find("CollectTransform").GetComponent<CollectScript>();
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
    }

   
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nest"))
        {
            Destroy(gameObject);

            //Sets the hasCollectable bool to false, so we may pick up another Item.
            collectScript.hasCollectable = false;
            //Updates the Score 
            uiManager.UpdateScore(pointValue);
        }
    }
}
