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
        bulletPrefab = Resources.Load<GameObject>("Assets/Prefabs/BulletPrefab");
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
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
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
