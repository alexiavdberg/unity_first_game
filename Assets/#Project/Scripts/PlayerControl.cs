using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    //public InputActions actions;

    public InputActionAsset actions;
    public float speed = 1f;
    private Rigidbody rb;
    public float intensityJump = 5f;
    public bool isGrounded;
    private InputAction xAxis;
    private InputAction jump;

    void Awake()
    {
        xAxis = actions.FindActionMap("CubeActionsMap").FindAction("XAxis");
        jump = actions.FindActionMap("CubeActionsMap").FindAction("jump");        
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable()
    {
        actions.FindActionMap("CubeActionsMap").Enable();
    }

    void OnDisable()
    {
        actions.FindActionMap("CubeActionsMap").Disable();
    }

    void Update()
    {
        MoveX();
        AutoMove();
        Jump();
    }

    private void MoveX()
    {
        float xMove = xAxis.ReadValue<float>();
        transform.position += speed * Time.deltaTime * xMove * transform.right;
    }

    private void AutoMove()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void Jump() 
    {
        float jumping = jump.ReadValue<float>();

        if (isGrounded) 
        {
            rb.AddForce(Vector3.up * jumping * intensityJump);
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.transform.CompareTag("Plane")) 
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Plane")) 
        {
            isGrounded = false;
        }
    }
}