using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform playerTransform; // Assign this in the inspector

    private Vector3 offset; // The relative offset of the camera from the player

    void Start()
    {
        // Calculate the initial offset.
        offset = transform.position - playerTransform.position;
    }

    void LateUpdate()
    {
        // Update the camera's position to follow the player.
        transform.position = playerTransform.position + offset;
    }
}
