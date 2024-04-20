using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed, lifeTime, damage, criticalChance, criticalMultiplier;

    //effect that bullet can have
    public bool explosive, piercing, chaining, hooming, scatter;

    private GameObject explosionPrefab;
    

      void Awake()
    {
        explosionPrefab = Resources.Load<GameObject>("Prefabs/ExplosivePrefab");
    }

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
    
    //if coliision with enemy, deal damage
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        EnemyScript enemy = hitInfo.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            enemy.health -= damage;	
            //Debug.Log("auch");
        }
        
        //if explosive, explode
        if (explosive)
        {
            Explosive();
        }
        
        //if piercing, keep going
        if (piercing)
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

void Explosive()
{
    
    // Define the explosion radius
    float explosionRadius = 2f;

    // Get all colliders within the explosion radius
    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

    // Instantiate the explosion effect
    GameObject explosionEffect = Instantiate(explosionPrefab, transform.position, Quaternion.identity);

    // Calculate the scale factor based on the original size of the prefab
    float originalSize = explosionEffect.GetComponent<Renderer>().bounds.size.x;
    float scaleFactor = (explosionRadius * 2) / originalSize;

    // Scale the explosion effect to match the explosion radius
    explosionEffect.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

    Destroy(explosionEffect, 0.2f);

    // Iterate over the colliders
    foreach (Collider2D collider in colliders)
    {
        // Check if the collider belongs to an enemy
        EnemyScript enemy = collider.GetComponent<EnemyScript>();
        if (enemy != null)
        {
            // Damage the enemy
            enemy.health -= damage/2;	
            //Destroy(collider.gameObject);
        }
    }
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
