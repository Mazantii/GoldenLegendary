using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Melee Weapon", menuName = "Melee Weapon")]
public class MeleeWeaponScript : ScriptableObject
{
    [SerializeField]
    private GameObject stabPrefab;
    public string weaponName;
    public float damage, attackRate, criticalChance, criticalMultiplier;
    public bool explosive, piercing, chaining, hooming, scatter;

    void Awake()
    {
        stabPrefab = Resources.Load<GameObject>("Prefabs/StabPrefab");
    }

    public enum StabMode
    {
        Single,
        Burst
    }
    public StabMode stabMode;

    //instansiates a stab with the stats of the weapon
    public void Attack(Transform firePoint)
    {
        // Get the player GameObject
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        // Get the PlayerMovement script
        PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();

        // Get the last move direction
        Vector2 lastMoveDirection = playerMovement.GetLastMoveDirection();

        // Calculate rotation based on lastMoveDirection
        float rotation = Mathf.Atan2(lastMoveDirection.y, lastMoveDirection.x) * Mathf.Rad2Deg - 90;

        // Set the rotation of the firePoint
        Vector3 offset = new Vector3(lastMoveDirection.x, lastMoveDirection.y, 0) * 1f;

        // Instantiate the stab
        GameObject stab = Instantiate(stabPrefab, firePoint.position + offset, Quaternion.Euler(0, 0, rotation));
        Stab stabScript = stab.GetComponent<Stab>();
        stabScript.damage = damage;
        stabScript.attackRate = attackRate;
        stabScript.criticalChance = criticalChance;
        stabScript.criticalMultiplier = criticalMultiplier;
        stabScript.explosive = explosive;
        stabScript.piercing = piercing;
        stabScript.chaining = chaining;
        stabScript.hooming = hooming;
        stabScript.scatter = scatter;
    }
}
