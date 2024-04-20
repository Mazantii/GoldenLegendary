using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float health;
    public float speed;
    public float damage;
    public float points;
    public float critChance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveTowardsPlayer();
    }

    //Function to walk towards the player 
    public void MoveTowardsPlayer()
    {
        //get the player position
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

        //if the player is found debug.log it
        if (playerPosition != null)
        {
            Debug.Log("Player found");
        }

        //get the direction to the player
        Vector3 direction = playerPosition - transform.position;

        //normalize the direction
        direction.Normalize();

        //move towards the player
        transform.position += direction * speed * Time.deltaTime;
    }
}
