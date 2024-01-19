using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{ //and behaviours
    private float minspeed = 1.0f;
    private float maxspeed = 4.0f;
    private float leftBound = -20;
    private float randomSpeed;

    
    // Start is called before the first frame update
    void Start()
    {
        randomSpeed = Random.Range(minspeed, maxspeed);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        //float randomSpeed = Random.Range(minspeed, maxspeed);
        transform.Translate(transform.right * -1 * randomSpeed * Time.deltaTime);

        //destroy out of bounds
        if (transform.position.x < leftBound)
        {
            SpawnManager.instance.ReturnBackToPool(gameObject);
            // Destroy(gameObject);
        }
    }
}
