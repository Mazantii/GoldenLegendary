using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100;
    public float maxHealth = 100;
    public float damage = 1;
    public int fireRate = 1;
    public float speed = 5;
    public float dodgeRate = 0f;
    public float CritRate = 0f;
    public int CritDamage = 2;

    //list with strings
    public List<string> blessings = new List<string>();
    public List<string> curses = new List<string>();

    public List<RangeWeaponScript> currentRangedWeapons;
    public List<MeleeWeaponScript> currentMeleeWeapons;
    private Transform firePoint;

    public static PlayerStats instance;


    void Start()
    {
        instance = this;
        //Find the script with the player Stats
        firePoint = transform;
        foreach (var weapon in currentRangedWeapons)
            {
                weapon.Shoot(firePoint);
                StartCoroutine(ShootRepeatedly());
            }
         foreach (var weapon in currentMeleeWeapons)
            {
                weapon.Attack(firePoint);
                StartCoroutine(StabRepeatedly());
            }
    }
    IEnumerator ShootRepeatedly()
    {
        while (true)
        {
            //if the weapons to add list is not empty, then add those weapons to the current ranged weapons list
            if(GameManager.instance.rangedWeaponsToAdd.Count > 0)
            {
                foreach (var weaponToAdd in GameManager.instance.rangedWeaponsToAdd)
                {
                    currentRangedWeapons.Add(weaponToAdd);
                }

                //then clear the list of ranged weapons to add
                GameManager.instance.rangedWeaponsToAdd.Clear();
            }
            foreach (var weapon in currentRangedWeapons)
            {
                weapon.Shoot(firePoint);
                //random number between 0 and 1
                float waitTime = UnityEngine.Random.Range(0f, 1f);
                yield return new WaitForSeconds(waitTime / weapon.fireRate);
            }
        }
    }
        IEnumerator StabRepeatedly()
    {
        while (true)
        {
            foreach (var weapon in currentMeleeWeapons)
            {
                weapon.Attack(firePoint);
                yield return new WaitForSeconds(1f / weapon.attackRate);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }


    //run this function when the player takes damage
    public void TakeDamage(float damage) //take damage from enemy
    {
        health -= damage;
        if (health <= 0)
        {
            //Change the game state to game over
            GameManager.instance.currentGameState = GameManager.GameState.GameOver;
            
        }
    }

/// <summary>
/// function that increases the player's stats
/// </summary>

    public void HealAtWaveEnd(int heal) //heal at the end of the level
    {
        health = maxHealth;
    }

    public void IncreaseDamage(int damageIncrease) //increase damage
    {
        damage += damageIncrease;
    }

    public void IncreaseFireRate(int fireRateIncrease) //increase fire rate
    {
        fireRate += fireRateIncrease;
    }

    public void IncreaseSpeed(int speedIncrease) //increase speed
    {
        speed += speedIncrease;
    }

    public void IncreaseDodgeRate(float dodgeRateIncrease) //increase dodge rate
    {
        dodgeRate += dodgeRateIncrease;
    }

    public void IncreaseCritRate(float critRateIncrease) //increase crit rate
    {
        CritRate += critRateIncrease;
    }

    public void IncreaseCritDamage(int critDamageIncrease) //increase crit damage
    {
        CritDamage += critDamageIncrease;
    }


/// <summary>
/// function that decreases the player's stats
/// </summary>
    
    public void DecreaseDamage(int damageDecrease) //decrease damage
    {
        damage -= damageDecrease;
    }

    public void DecreaseFireRate(int fireRateDecrease) //decrease fire rate
    {
        fireRate -= fireRateDecrease;
    }

    public void DecreaseSpeed(int speedDecrease) //decrease speed
    {
        speed -= speedDecrease;
    }

    public void DecreaseDodgeRate(float dodgeRateDecrease) //decrease dodge rate
    {
        dodgeRate -= dodgeRateDecrease;
    }

    public void DecreaseCritRate(float critRateDecrease) //decrease crit rate
    {
        CritRate -= critRateDecrease;
    }

    public void DecreaseCritDamage(int critDamageDecrease) //decrease crit damage
    {
        CritDamage -= critDamageDecrease;
    }


/// <summary>
/// function that resets the player's stats
/// </summary>
    public void ResetStats() //reset stats if died
    {
        health = maxHealth;
        damage = 1;
        fireRate = 1;
        speed = 5;
        dodgeRate = 0f;
        CritRate = 0f;
        CritDamage = 2;
    }

}
