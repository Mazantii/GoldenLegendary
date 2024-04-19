using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction movement;

    //player stats
    PlayerStats playerStats;

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        movement = playerInput.actions["Move"];

        //Find the script with the player Stats
        playerStats = GetComponent<PlayerStats>();

        
    }

    void Update()
    {
        MovePLayer();
    }

    void MovePLayer()
    {
        Vector2 move = movement.ReadValue<Vector2>();
        transform.position += new Vector3(move.x, move.y, 0) * playerStats.speed * Time.deltaTime;
    }

}
