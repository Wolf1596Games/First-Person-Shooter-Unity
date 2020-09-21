using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with" + other.gameObject.name);

        if (other.CompareTag("Player"))
        {
            
            int health = player.GetHealth();
            health -= 15;
            player.SetHealth(health);
        }

        Destroy(gameObject);
    }
}
