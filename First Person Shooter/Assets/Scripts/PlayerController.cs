﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Info")]
    [Range(0, 100)] [SerializeField] int playerHealth = 100;
    [SerializeField] int playerAmmo = 100;

    [Header("Movement")]
    [SerializeField] float playerSpeed = 1f;
    [SerializeField] float jumpForce = 1f;
    [SerializeField] float rotSpeed = 1f;
    [SerializeField] float jumpRaycastDistance = 1f;
    [SerializeField] Transform cam;

    [Header("Firing")]
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] GameObject projectilePrefab;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        //Mouse Input
        float x = Input.GetAxis("Mouse X");
        transform.Rotate(new Vector3(0, x * rotSpeed, 0));

        Move(h, v);

        if(Input.GetButtonDown("Fire1") && playerAmmo != 0)
        {
            Fire();
        }

        Ray r = new Ray(transform.position, Vector3.down);
        Debug.DrawLine(r.origin, r.origin + (Vector3.down * jumpRaycastDistance));
        RaycastHit hit;

        if(Input.GetButtonDown("Jump") && Physics.Raycast(r, out hit, jumpRaycastDistance))
        {
            Jump();
        }
    }

    private void Fire()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity) as GameObject;
        projectile.GetComponent<Rigidbody>().velocity = transform.forward * projectileSpeed;

        playerAmmo--;
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

    public int GetHealth()
    {
        return playerHealth;
    }
    public void SetHealth(int health)
    {
        playerHealth = health;
    }
    public int GetAmmo()
    {
        return playerAmmo;
    }
    public void SetAmmo(int ammo)
    {
        playerAmmo = ammo;
    }
}
