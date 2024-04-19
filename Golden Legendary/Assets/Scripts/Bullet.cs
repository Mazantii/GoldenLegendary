using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed, lifeTime, damage, criticalChance, criticalMultiplier;

    //effect that bullet can have
    public bool explosive, piercing, chaining, hooming, scatter;


    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        
    }

    // fixed update is called every frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        
    }
    
    //deals damage to the enemy
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        /*Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);*/
    }

    void Explosive()
    {
        //explosive effect
    }

    void Piercing()
    {
        //piercing effect
    }

    void Chaining()
    {
        //chaining effect
    }

    void Hooming()
    {
        //hooming effect
    }

    void Scatter()
    {
        //scatter effect
    }

}
