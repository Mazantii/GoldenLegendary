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

    public float wavePoints = 100;
    public int waveNumber = 1;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentGameState = GameState.Start;


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //Make a function to change the game state to Wave
    public void StartWave()
    {
        currentGameState = GameState.Wave;

    }
}
