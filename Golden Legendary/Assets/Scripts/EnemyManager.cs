using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    //a list with all the enemies where you can add the stats of the enemies
    public List<Enemy> enemies = new List<Enemy>();
    public List<Enemy> bosses = new List<Enemy>();

    public float waitTimeBetweenSpawn = 1f;

    bool spawn = true;



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
    public IEnumerator SpawnEnemyCoroutine(float waitTime)
    {
        Debug.Log("Spawning enemy");
        //while the wave points are more than 0
        while (GameManager.instance.wavePoints > 0)
        {
            //Every 5th wave spawn bosses
            if (GameManager.instance.waveNumber % 5 == 0)
            {
                //get a random boss from the list
                Enemy boss = bosses[Random.Range(0, bosses.Count)];

                //remove the boss.points from the wave points in the game manager
                GameManager.instance.wavePoints -= boss.points;

                // Instantiate the boss and get a reference to the new instance and spawn it at a random position on the "Background"
                GameObject bossInstance = Instantiate(boss.enemyPrefab, new Vector3(Random.Range(-45, 45), Random.Range(-45, 45), 0), Quaternion.identity);
                // Get the EnemyScript component of the new instance and modify its stats
                EnemyScript bossScript = bossInstance.GetComponent<EnemyScript>();
                bossScript.health = boss.health;
                bossScript.speed = boss.speed;
                bossScript.damage = boss.damage;
                bossScript.critChance = boss.critChance;
                bossScript.points = boss.points;

                //give the boss the tag "Boss"
                bossInstance.tag = "Boss";

                //wait for the waitTime before spawning the next boss
                yield return new WaitForSeconds(waitTime);
            }

            Debug.Log("Wave points: " + GameManager.instance.wavePoints);
            //get a random enemy from the list
            Enemy enemy = enemies[Random.Range(0, enemies.Count)];

            //remove the enemy.points from the wave points in the game manager
            GameManager.instance.wavePoints -= enemy.points;

            // Instantiate the enemy and get a reference to the new instance and spawn it at a random position on the "Background"
            GameObject enemyInstance = Instantiate(enemy.enemyPrefab, new Vector3(Random.Range(-45, 45), Random.Range(-45, 45), 0), Quaternion.identity);
            // Get the EnemyScript component of the new instance and modify its stats
            EnemyScript enemyScript = enemyInstance.GetComponent<EnemyScript>();
            enemyScript.health = enemy.health;
            enemyScript.speed = enemy.speed;
            enemyScript.damage = enemy.damage;
            enemyScript.critChance = enemy.critChance;
            enemyScript.points = enemy.points;

            //give the enemy the tag "Enemy"
            enemyInstance.tag = "Enemy";

            //wait for the waitTime before spawning the next enemy
            yield return new WaitForSeconds(waitTime);
        }

        //start the coroutine to check if all the enemies are ded
        StartCoroutine(CheckIfAllEnemiesAreDead());

        //update the wave number
        GameManager.instance.waveNumber++;

        //when the wave points are 0 stop the coroutine
        StopCoroutine(SpawnEnemyCoroutine(2f));

    
    }

    public void StartWave()
    {
        StartCoroutine(SpawnEnemyCoroutine(waitTimeBetweenSpawn));
    }

    //Coroutine to watch if all the enemies are dead
    public IEnumerator CheckIfAllEnemiesAreDead()
    {
        //while there are enemies in the scene
        while (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
        {
            //wait for 1 second before checking again
            yield return new WaitForSeconds(1f);
        }

        Debug.Log("All enemies are dead");
        //when there are no enemies in the scene change the game state to shop
        GameManager.instance.currentGameState = GameManager.GameState.Shop;
        GameManager.instance.hasWaveStarted = false;
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
