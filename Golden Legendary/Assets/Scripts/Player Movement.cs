using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    PlayerInput playerInput;
    InputAction movement;

    //private Animator anim;


    //player stats
    PlayerStats playerStats;

    void Start()
    {
        
        playerInput = GetComponent<PlayerInput>();
        movement = playerInput.actions["Move"];
        //anim = GetComponent<Animator>();

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

        /*if(move = movement.ReadValue<Vector2>("A"))
        {
            anim.SetBool("isAttackingLeft", true);
        }
        else if(move = movement.ReadValue<Vector2>("D"))
        {
            anim.SetBool("isAttackingRight", true);
        }*/

        transform.position += new Vector3(move.x, move.y, 0) * playerStats.speed * Time.deltaTime;
    }

}
