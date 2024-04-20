using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stab : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage, attackRate, criticalChance, criticalMultiplier;
    public bool explosive, piercing, chaining, hooming, scatter;
    void Start()
    {
        Destroy(gameObject, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {

        
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
