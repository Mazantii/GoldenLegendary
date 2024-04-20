using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //This script will be used to manage the game we use it to keep track of the Game state

    public static GameManager instance;

    public enum GameState
    {
        Start,
        Wave,
        Shop,
    }

    public GameState currentGameState;

    public WaveManager waveManager;
    public float maxWavePoints;
    public float wavePoints = 100;
    public int waveNumber = 1;

    public bool hasWaveStarted = false;

    Vector2 playerPosition;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentGameState = GameState.Start;
        maxWavePoints = wavePoints;
    }

    // Update is called once per frame
    void Update()
    {
        //get the player position from the game objevt called player in 2D
        Vector2 playerPosition = GameObject.Find("Player").transform.position;
        

        


        //if the gamestate changes to wave start the wave once
        if (currentGameState == GameState.Wave && !hasWaveStarted)
        {
            Debug.Log("Wave " + waveNumber + " has started");
            EnemyManager.instance.StartWave();
            hasWaveStarted = true;
        }
        if(currentGameState == GameState.Shop)
        {
            waveNumber++;
            //Den her skal gøres når man trykker op klar knappen
            //wavePoints = maxWavePoints;
            currentGameState = GameState.Wave;
        }
        
    }

    
}
