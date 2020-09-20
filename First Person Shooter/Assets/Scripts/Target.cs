using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Transform currentTarget;
    [Header("Target Movement")]
    [SerializeField] Transform[] targets;
    int targetIndex = 0;
    [SerializeField] float dist;

    [Header("Target Stats")]
    [SerializeField] float speed;
    [SerializeField] int health = 15;

    GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        UpdateTarget();

        manager = FindObjectOfType<GameManager>();

        CountTargets();
    }

    private void CountTargets()
    {
        if(tag == "Target")
        {
            manager.CountTargets();
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentTarget.position, speed * Time.deltaTime);

        if(Vector3.Distance(transform.position, currentTarget.position) < dist)
        {
            targetIndex++;

            if(targetIndex == targets.Length)
            {
                targetIndex = 0;
            }

            UpdateTarget();
        }

        if(health <= 0)
        {
            DestroyTarget();
        }
    }

    private void DestroyTarget()
    {
        Destroy(gameObject);
        manager.TargetDestroyed();
    }

    void UpdateTarget()
    {
        currentTarget = targets[targetIndex];
    }

    private void OnTriggerEnter(Collider other)
    {
        health--;
    }
}
