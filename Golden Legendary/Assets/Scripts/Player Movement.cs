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

    //Vector2 to store the last move direction
    Vector2 lastMoveDirection;

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

        if (move != Vector2.zero)
        {
            lastMoveDirection = move;
        }

        transform.position += new Vector3(move.x, move.y, 0) * playerStats.speed * Time.deltaTime;
    }

    public Vector2 GetLastMoveDirection()
    {
        return lastMoveDirection;
    }

}
