using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Range Weapon", menuName = "Range Weapon")]

public class RangeWeaponScript : ScriptableObject
{

    public GameObject bulletPrefab;

    //stats for the ranged weapon
    public string weaponName;
    public float damage;
    public float fireRate;
    public float bulletSpeed;
    public float bulletLifeTime;

    public bool LightningMode = true; 

    //chose between single shot or burst fire in a dropdown menu
    public enum FireMode
    {
        Single,
        Burst
    }

    public FireMode fireMode;



}
