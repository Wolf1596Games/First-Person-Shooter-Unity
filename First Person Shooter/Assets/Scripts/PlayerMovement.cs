using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 1f;
    [SerializeField] float jumpForce = 1f;
    [SerializeField] float raycastDistance = 1f;
    [SerializeField] Transform cam;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Move(h, v);

        Ray r = new Ray(transform.position, Vector3.down);
        Debug.DrawLine(r.origin, r.origin + (Vector3.down * raycastDistance));
        RaycastHit hit;

        if(Input.GetButtonDown("Jump") && Physics.Raycast(r, out hit, raycastDistance))
        {
            Jump();
        }
    }

    private void Move(float h, float v)
    {
        Vector3 camForward = cam.forward;
        Vector3 camRight = cam.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 moveDirection = (camForward * v * playerSpeed) + (camRight * h * playerSpeed);

        rb.velocity = new Vector3(moveDirection.x, rb.velocity.y, moveDirection.z);
    }

    public void Jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
    }
}
