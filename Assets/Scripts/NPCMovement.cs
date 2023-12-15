using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{ //and behaviours
    public float speed = 5.0f;
    public float leftBound = -20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right * -1 * speed * Time.deltaTime);
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
        }
    }
}
