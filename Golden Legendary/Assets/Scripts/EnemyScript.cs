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

    public GameObject target;

    public float damageCooldown = 1f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        MoveTowardsPlayer();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveTowardsPlayer();

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        //damage cooldown
        if (damageCooldown > 0)
        {
            damageCooldown -= Time.deltaTime;
        }
    }

    //Function to walk towards the player 
    public void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    //Function to deal damage to the player oncollision2D
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Debug.Log(hitInfo.name);
        PlayerStats player = hitInfo.GetComponent<PlayerStats>();
        if (player != null)
        {
            if(damageCooldown <= 0)
            {
                player.TakeDamage(damage);
                damageCooldown = 1f;
            }
        }
    }

    //Function to deal damage to the player while in collision
    void OnTriggerStay2D(Collider2D hitInfo)
    {
        PlayerStats player = hitInfo.GetComponent<PlayerStats>();
        if (player != null)
        {
            if (damageCooldown <= 0)
            {
                player.TakeDamage(damage);
                damageCooldown = 1f;
            }
        }
    }


}
