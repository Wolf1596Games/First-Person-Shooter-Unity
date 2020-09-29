using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] float rotSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Mouse Y");

        transform.Rotate(y * rotSpeed, 0, 0);
    }
}
