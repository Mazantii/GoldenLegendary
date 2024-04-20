using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public static WaveManager instance;
    public GameManager gameManager;

    public float wavePoints;
    public int waveNumber;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        gameManager = GameManager.instance;
        
    }

    void Update()
    {
    }

    //make a Corrutine that spawns enemies every 2 seconds and stops when the wave points are 0


}
