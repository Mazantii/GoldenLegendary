using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Game State")]
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

    public Vector2 playerPosition;

    [Header("Shop")]
    public GameObject shopUI;
    public GameObject blessing1;
    public GameObject blessing1Description;
    public GameObject blessing2;
    public GameObject blessing2Description;
    public GameObject blessing3;
    public GameObject blessing3Description;


    


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
            shopUI.SetActive(false);
            Debug.Log("Wave " + waveNumber + " has started");
            EnemyManager.instance.StartWave();
            hasWaveStarted = true;
        }
        if(currentGameState == GameState.Shop)
        {
            hasWaveStarted = false;
            //turn on the shop UI in the canvas
            shopUI.SetActive(true);

            //Get random tier blessings
            BlessingAndCursesScript.Blessings blessingTier1 = BlessingAndCursesScript.instance.GetRandomTier1Blessing();
            BlessingAndCursesScript.Blessings blessingTier2 = BlessingAndCursesScript.instance.GetRandomTier2Blessing();
            BlessingAndCursesScript.Blessings blessingTier3 = BlessingAndCursesScript.instance.GetRandomTier3Blessing();
            
            Debug.Log("Blessing: " + blessingTier1.blessingName);

            //set the blessingtext in the shop UI
            blessing1.GetComponent<TextMeshProUGUI>().text = blessingTier1.blessingName;
            blessing1Description.GetComponent<TextMeshProUGUI>().text = blessingTier1.blessingDescription;

            blessing2.GetComponent<TextMeshProUGUI>().text = blessingTier2.blessingName;
            blessing2Description.GetComponent<TextMeshProUGUI>().text = blessingTier2.blessingDescription;

            blessing3.GetComponent<TextMeshProUGUI>().text = blessingTier3.blessingName;
            blessing3Description.GetComponent<TextMeshProUGUI>().text = blessingTier3.blessingDescription;

        }
        
    }

        //function that passes the name of the blessingTier1
        public void BuyBlessing1()
        {
            BlessingAndCursesScript.Blessings blessingTier1 = BlessingAndCursesScript.instance.GetRandomTier1Blessing();
            Debug.Log("Blessing: " + blessingTier1.blessingName);
        }



    
}
