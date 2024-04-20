using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Range Weapon", menuName = "Range Weapon")]

public class RangeWeaponScript : ScriptableObject
{
    [SerializeField]
    private GameObject bulletPrefab;

    void Awake()
    {
        bulletPrefab = Resources.Load<GameObject>("Prefabs/BulletPrefab");
    }

    //stats for the ranged weapon
    public string weaponName;
    public float damage, fireRate, bulletSpeed, bulletLifeTime, criticalChance, criticalMultiplier;

    //effect that bullet can have
    public bool explosive, piercing, chaining, hooming, scatter;


    //chose between single shot or burst fire in a dropdown menu
    public enum FireMode
    {
        Single,
        Burst
    }
    public FireMode fireMode;

//instansiates a bullet with the stats of the weapon
    public void Shoot(Transform firePoint)
    {
    // Get all enemies
    GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

    // Find the nearest enemy
    GameObject nearestEnemy = null;
    float minDistance = Mathf.Infinity;
    foreach (GameObject enemy in enemies)
    {
        float distance = Vector2.Distance(firePoint.position, enemy.transform.position);
        if (distance < minDistance)
        {
            minDistance = distance;
            nearestEnemy = enemy;
        }
    }

    // Calculate the rotation
    float rotation;
    if (nearestEnemy != null)
    {
        // If there's at least one enemy, calculate the direction towards the nearest enemy
        Vector2 direction = nearestEnemy.transform.position - firePoint.position;
        rotation = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    }
    else
    {
        // If there are no enemies, calculate a random rotation
        rotation = Random.Range(0, 360);
    }

    // Instantiate the bullet
    GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(0, 0, rotation));
    Bullet bulletScript = bullet.GetComponent<Bullet>();
    bulletScript.speed = bulletSpeed;
    bulletScript.lifeTime = bulletLifeTime;
    bulletScript.damage = damage;
    bulletScript.criticalChance = criticalChance;
    bulletScript.criticalMultiplier = criticalMultiplier;
    bulletScript.explosive = explosive;
    bulletScript.piercing = piercing;
    bulletScript.chaining = chaining;
    bulletScript.hooming = hooming;
    bulletScript.scatter = scatter;
}
}
