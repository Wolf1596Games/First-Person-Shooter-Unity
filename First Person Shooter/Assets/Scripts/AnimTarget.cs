using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimTarget : MonoBehaviour
{
    [SerializeField] Transform target;

    [Header("Target Stats")]
    [SerializeField] float speed;
    [SerializeField] int health = 15;

    GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();

        CountTargets();
    }

    private void CountTargets()
    {
        if (tag == "Target")
        {
            manager.CountTargets();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            DestroyTarget();
        }

        transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
    }

    private void DestroyTarget()
    {
        Destroy(gameObject);
        manager.TargetDestroyed();
    }
    private void OnTriggerEnter(Collider other)
    {
        health--;
    }
}
