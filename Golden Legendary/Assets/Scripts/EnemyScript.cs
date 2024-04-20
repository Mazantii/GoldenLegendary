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
    }

    //Function to walk towards the player 
    public void MoveTowardsPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
}
