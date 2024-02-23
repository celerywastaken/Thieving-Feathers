using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollecatableBehaviour : MonoBehaviour
{
    [SerializeField] private UIManager uiManager;                // Reference to the UIManager script
    [SerializeField] private CollectScript collectScript;       // Reference to the CollectScript script

    [SerializeField]private int pointValue;                   // The value of the collectible
    [SerializeField] private AudioSource collectSFX;         // Reference to the AudioSource for collect sound effects
    [SerializeField] private ParticleSystem collectBurst;   // Reference to the ParticleSystem for collect burst effects
    void Start()
    {
        //Gets a hold of the CollectSCript from the CollectTransform
        collectScript = GameObject.Find("CollectTransform").GetComponent<CollectScript>();

        // Gets a reference to the UIManager from the GameObject named "UIManager"
        uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();

        // Gets a reference to the AudioSource from the GameObject named "CollectTransform"
        collectSFX = GameObject.Find("CollectTransform").GetComponent<AudioSource>();

        // Gets a reference to the ParticleSystem from the GameObject named "Nest Particles"
        collectBurst = GameObject.Find("Nest Particles").GetComponent <ParticleSystem>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider's tag is "Nest"
        if (other.CompareTag("Nest"))
        {
            // Destroy the current GameObject (the collectible)
            Destroy(gameObject);

            // Play the collect sound effect
            collectSFX.Play();

            // Play the collect burst particle effect
            collectBurst.Play();

            //Sets the hasCollectable bool to false, so we may pick up another Item.
            collectScript.hasCollectable = false;

            //Updates the Score 
            uiManager.UpdateScore(pointValue);
        }
    }
}
