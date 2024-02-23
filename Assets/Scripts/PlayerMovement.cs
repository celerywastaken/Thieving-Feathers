using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;

    private Vector2 moveDirection;

    private float xRange = 8;
    private float yRange = 5;

    private float speed = 6.0f;


    public Rigidbody2D player;
    public SpriteRenderer spriteRenderer;

   [SerializeField] private Transform pickUpTransform;
    
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInput();
        KeepingInBounds();
    }

    private void GetInput()
    {
        // gets the Inputs from the InputManager
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    { 
        //Moving based on Physics
       moveDirection = new Vector2(horizontalInput, verticalInput);
       transform.Translate(moveDirection.normalized * Time.deltaTime * speed);
       
        //flips the Sprite depending on the Move Direction
       spriteRenderer.flipX = moveDirection.x < 0f;
    }

    private void KeepingInBounds()
    {
        //Destroying NPC's out of Bounds for better Performance
        if (transform.position.x < -xRange)
        { transform.position = new Vector2(-xRange, transform.position.y); }

        if (transform.position.x > xRange)
        { transform.position = new Vector2(xRange, transform.position.y); }

        if(transform.position.y < -yRange)
        { transform.position = new Vector2(transform.position.x, -yRange); }

        if (transform.position.y > yRange)
        { transform.position = new Vector2(transform.position.x, yRange); }
    }

    public void CollectItem(Transform itemToCollect)
    {

        //Sets the Collected Items Position to the PickUp Position
        itemToCollect.position = pickUpTransform.position;

        //Makes the Collected Item a Child of the PickUp Transform
        itemToCollect.SetParent(pickUpTransform);
    }


 
}
