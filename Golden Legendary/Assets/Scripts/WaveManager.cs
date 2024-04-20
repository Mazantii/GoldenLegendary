using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public static WaveManager instance;
    public GameManager gameManager;

    public float wavePoints;
    public int waveNumber;



    //here we have all the waves and the logic for the waves gamestate


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gameManager = GameManager.instance;
        
    }

    void Update()
    {
        if (gameManager.currentGameState == GameManager.GameState.Wave)
        {
            StartWave(GameManager.instance.wavePoints, GameManager.instance.waveNumber);
        }
        
    }

    //make a corrutine to start the wave
    public void StartWave(float wavePoints, int waveNumber)
    {
        this.wavePoints = wavePoints;
        this.waveNumber = waveNumber;
        StartCoroutine(StartWaveCoroutine());
    }

    IEnumerator StartWaveCoroutine()
    {
        gameManager.currentGameState = GameManager.GameState.Wave;

        //when the last enemy is dead we will change the game state to shop
        yield return new WaitUntil(() => EnemyManager.instance.enemies.Count == 0);
        
    }

}
