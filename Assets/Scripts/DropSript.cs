using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropSript : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;
    public CollectScript collectScript;
    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        player = GetComponentInParent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Nest"))
        {   
            if(!collectScript.hasCollectable) { return; }
           
            player.DropCollectable(collectScript.GetPickedUpCollectableBehaviour().GetCollectableType());
            // Destroy(gameObject);

            //Sets the hasCollectable bool to false, so we may pick up another Item.
            collectScript.hasCollectable = false;
            //Updates the Score 
            uiManager.UpdateScore(collectScript.GetPickedUpCollectableBehaviour().GetPointValue());
        }
    }
}
