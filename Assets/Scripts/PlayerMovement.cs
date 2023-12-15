using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    private Vector2 moveDirection;

    public float speed = 10.0f;

    public Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        moveDirection = new Vector2 (horizontalInput, verticalInput);   
    }

    private void FixedUpdate()
    {
        transform.Translate(moveDirection.normalized * Time.deltaTime * speed);
    //    playerRb.AddForce(moveDirection.normalized * speed, ForceMode2D.Force);
    //    playerRb.velocity += moveDirection.normalized * speed * Time.fixedDeltaTime;
    }
}
