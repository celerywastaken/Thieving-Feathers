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

    public float speed = 10.0f;

    [SerializeField] private Transform pickUpTransform;
    void Start()
    {
        
    }

    void Update()
    {
        GetInput();
        KeepingInBounds();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void FixedUpdate()
    { 
       moveDirection = new Vector2(horizontalInput, verticalInput);
       transform.Translate(moveDirection.normalized * Time.deltaTime * speed);
       //playerRb.AddForce(moveDirection.normalized * speed, ForceMode2D.Force);
       //playerRb.velocity += moveDirection.normalized * speed * Time.fixedDeltaTime;
    }

    private void KeepingInBounds()
    {
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
        itemToCollect.position = pickUpTransform.position;
        itemToCollect.SetParent(pickUpTransform);
        
    }
}
