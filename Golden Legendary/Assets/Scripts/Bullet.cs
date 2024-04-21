using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed, lifeTime, damage, criticalChance, criticalMultiplier;

    //effect that bullet can have
    public bool explosive, piercing, chaining, hooming, scatter;

    private GameObject explosionPrefab;
    private GameObject bulletPrefab;
    public Vector2 lastDirection;
    public GameObject spawningTarget;
    

      void Awake()
    {
        explosionPrefab = Resources.Load<GameObject>("Prefabs/ExplosivePrefab");
        bulletPrefab = Resources.Load<GameObject>("Prefabs/BulletPrefab");
    }

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifeTime);
        
    }

    private List<EnemyScript> hitEnemies = new List<EnemyScript>();
    private EnemyScript currentTarget = null;

    // fixed update is called every frame
void FixedUpdate()
{

    if (hooming)
    {
        if (currentTarget == null)
        {
            Homing();
        }
        else
        {
            // If there's a current target, move towards it
            float step = speed * Time.deltaTime; // calculate distance to move
            transform.position = Vector2.MoveTowards(transform.position, currentTarget.transform.position, step);
        }
    }
    else
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
    
}
    
    //if coliision with enemy, deal damage
void OnTriggerEnter2D(Collider2D hitInfo)
{
    
    
        EnemyScript enemy = hitInfo.GetComponent<EnemyScript>();

        //if colliding with the player ignore
        if (hitInfo.tag == "Player")
        {
            return;
        }

        if (enemy != null)
        {
            enemy.health -= damage;	
                
            hitEnemies.Add(enemy);

            // Home in on the next enemy
            currentTarget = null;
        }
            
        //if explosive, explode
        if (explosive)
        {
            Explosive(hitInfo.transform.position);
        }

        if (chaining)
        {
            Chaining(hitInfo, 5);
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

void Explosive(Vector3 position)
{
    
       // Define the explosion radius
    float explosionRadius = 2f;

    // Instantiate the explosion effect at the given position
    GameObject explosionEffect = Instantiate(explosionPrefab, position, Quaternion.identity);

    // Calculate the scale factor based on the original size of the prefab
    float originalSize = explosionEffect.GetComponent<Renderer>().bounds.size.x;
    float scaleFactor = (explosionRadius * 2) / originalSize;

    // Scale the explosion effect to match the explosion radius
    explosionEffect.transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);

    // Destroy the explosion effect after 2 seconds
    Destroy(explosionEffect, 0.1f);
}

void Chaining(Collider2D originalTarget, int remainingChains, List<EnemyScript> hitEnemies = null)
{
    // Base case: no more chains remaining
    if (remainingChains <= 0) return;

    // Initialize the list of hit enemies if it's null
    if (hitEnemies == null)
    {
        hitEnemies = new List<EnemyScript>();
    }

    // Add the original target to the list of hit enemies
    hitEnemies.Add(originalTarget.GetComponent<EnemyScript>());

    // Get all enemies in the scene
    EnemyScript[] allEnemies = FindObjectsOfType<EnemyScript>();

    // Find the nearest enemy that hasn't been hit yet
    EnemyScript nearestEnemy = null;
    float minDistance = float.MaxValue;
    foreach (EnemyScript enemy in allEnemies)
    {
        // Check if the enemy is not the original target and hasn't been hit yet
        if (enemy.GetComponent<Collider2D>() != originalTarget && !hitEnemies.Contains(enemy))
        {
            float distance = Vector2.Distance(originalTarget.transform.position, enemy.transform.position);
            if (distance < minDistance)
            {
                nearestEnemy = enemy;
                minDistance = distance;
            }
        }
    }

    // If an enemy was found, damage it and chain to the next enemy
    if (nearestEnemy != null)
    {
        nearestEnemy.health -= damage;

        if (explosive)
        {
            Explosive(nearestEnemy.transform.position);
        }

        // Draw a line from the original target to the nearest enemy
        GameObject lineObject = new GameObject("ChainLine");
        LineRenderer line = lineObject.AddComponent<LineRenderer>();
        line.SetPosition(0, originalTarget.transform.position);
        line.SetPosition(1, nearestEnemy.transform.position);
        line.material = new Material(Shader.Find("Sprites/Default"));
        line.startColor = line.endColor = Color.white;
        line.startWidth = line.endWidth = 0.1f;

        // Chain to the next enemy
        Chaining(nearestEnemy.GetComponent<Collider2D>(), remainingChains - 1, hitEnemies);

        // Destroy the line object after 0.1 seconds
        Destroy(lineObject, 0.1f);
    }
}

void Homing()
{
    // Get all enemies in the scene
    EnemyScript[] allEnemies = FindObjectsOfType<EnemyScript>();

    if (allEnemies.Length == 0)
    {
        // If there are no enemies left, stop homing and return
        hooming = false;
        return;
    }

    EnemyScript nearestEnemy = null;
    float minDistance = float.MaxValue;
    foreach (EnemyScript enemy in allEnemies)
    {
        // Skip this enemy if it has already been hit
        if (hitEnemies.Contains(enemy))
        {
            continue;
        }

        float distance = Vector2.Distance(transform.position, enemy.transform.position);
        if (distance < minDistance)
        {
            nearestEnemy = enemy;
            minDistance = distance;
        }
    }

    // If an enemy was found, move towards it
    if (nearestEnemy != null)
    {
        currentTarget = nearestEnemy;
    }
    else
    {
        // If no valid enemy was found, stop homing
        hooming = false;
    }
}

/*void Scatter()
{
    Debug.Log("Scatter");
    // Directions for the scatter shots
    Vector2[] directions = new Vector2[]
    {
        Vector2.up,
        Vector2.down,
        Vector2.left,
        Vector2.right
    };
    foreach (Vector2 direction in directions)
    {
        Debug.Log("Scattering");
        // Instantiate a new bullet and set its direction
        GameObject bullet = Instantiate(bulletPrefab, transform.position + (Vector3)direction * 0.1f, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.lastDirection = direction;
        bulletScript.hooming = false; // Prevent the new bullet from homing
        bulletScript.spawningTarget = this.gameObject;; // Set the spawning target to the current bullet
        bulletScript.speed = speed;
        bulletScript.lifeTime = lifeTime;
        bulletScript.damage = damage;
        bulletScript.criticalChance = criticalChance;
        bulletScript.criticalMultiplier = criticalMultiplier;
        bulletScript.explosive = explosive;
        bulletScript.piercing = piercing;
        bulletScript.chaining = chaining;
        bulletScript.scatter = false;
    }
}*/

}
