using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayHealth : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI healthText;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = player.GetHealth().ToString();
    }
}
