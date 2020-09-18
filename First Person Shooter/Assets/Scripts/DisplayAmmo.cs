using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayAmmo : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ammoText;
    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        ammoText.text = player.GetAmmo().ToString();
    }
}
