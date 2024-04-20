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

    void Awake()
    {
        stabPrefab = Resources.Load<GameObject>("Assets/Prefabs/StabPrefab");
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
        GameObject stab = Instantiate(stabPrefab, firePoint.position, firePoint.rotation);
        Stab stabScript = stab.GetComponent<Stab>();
        stabScript.damage = damage;
        stabScript.attackRate = attackRate;
        stabScript.criticalChance = criticalChance;
        stabScript.criticalMultiplier = criticalMultiplier;
    }
}
