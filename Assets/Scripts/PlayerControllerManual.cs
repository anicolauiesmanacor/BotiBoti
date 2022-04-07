using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerManual : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotateSpeed = 60f;

    private float hInput, vInput;

    private Vector3 moveDirection;
    private float jumpSpeed = 0.5f;
    private float gravity = 1.5f;
    
    [SerializeField]
    private bool isGrounded;
    
    // Start is called before the first frame update
    void Start()
    {
        isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        hInput = Input.GetAxis("Horizontal") * rotateSpeed;
        vInput = Input.GetAxis("Vertical") * moveSpeed;
    }

    private void FixedUpdate()
    {
        this.transform.Translate(vInput*Time.deltaTime*Vector3.forward);
        this.transform.Rotate(hInput*Time.deltaTime*Vector3.up);
        
        if (isGrounded)
        {
            if (moveDirection.y != 0)
            {
                moveDirection.y = 0;    
            }
            
            if (Input.GetKey(KeyCode.Space))
            {
                moveDirection.y = jumpSpeed;
                isGrounded = false;
            }
        }
        else
        {
            moveDirection.y -= gravity * Time.fixedDeltaTime;
        }
        transform.Translate(moveDirection);
        
        if (this.gameObject.transform.position.y < -50)
        {
            this.GetComponent<GameManager>().isGameOver = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
