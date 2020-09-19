using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    PlayerController player;


    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }
    private void OnTriggerEnter(Collider other)
    {
        player.SetAmmo(100);

        Destroy(gameObject);
    }
}
