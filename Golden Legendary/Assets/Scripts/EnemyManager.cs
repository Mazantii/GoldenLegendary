using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    //a list with all the enemies where you can add the stats of the enemies
    public List<Enemy> enemies = new List<Enemy>();



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //function to get a random enemy from the list and spawn it at a random position but at most 100 units away from the player
    public void SpawnEnemy()
    {

        //get a random enemy from the list
        Enemy enemy = enemies[Random.Range(0, enemies.Count)];


        //while there are still points left in the wave we will spawn enemies
        while(WaveManager.instance.wavePoints > 0)
        {
            //instansiate the enemy
            Instantiate(enemy.enemyPrefab, new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100)), Quaternion.identity);

            //give the instance of the enemy the stats of the enemy
            enemy.enemyPrefab.GetComponent<EnemyScript>().health = enemy.health;
            enemy.enemyPrefab.GetComponent<EnemyScript>().speed = enemy.speed;
            enemy.enemyPrefab.GetComponent<EnemyScript>().damage = enemy.damage;
            enemy.enemyPrefab.GetComponent<EnemyScript>().critChance = enemy.critChance;

            //remove the points of the enemy from the wave points
            WaveManager.instance.wavePoints -= enemy.points;
        }

        //get a random position
        Vector3 randomPosition = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));

        //if the random position is more than 100 units away from the player we will get a new random position
        while (Vector3.Distance(randomPosition, GameObject.FindGameObjectWithTag("Player").transform.position) > 100)
        {
            randomPosition = new Vector3(Random.Range(-100, 100), 0, Random.Range(-100, 100));
        }

        //spawn the enemy with the stats of the random enemy at the random position

    }
    


    //make a class for the enemies with stats
    [System.Serializable]
    public class Enemy
    {
        public float health;
        public float speed;
        public float damage;
        public float points;
        public float critChance;
        public GameObject enemyPrefab;
    }
}
