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
        GameOver
    }

    public GameState currentGameState;

    public WaveManager waveManager;
    public float maxWavePoints;
    public float wavePoints = 100;
    public int waveNumber = 0;

    public bool hasWaveStarted = false;
    public bool haveRolledBlessings = false;

    public Vector2 playerPosition;

    [Header("Shop")]
    public GameObject shopUI;
    public GameObject blessing1;
    public GameObject blessing1Description;
    public GameObject blessing2;
    public GameObject blessing2Description;
    public GameObject blessing3;
    public GameObject blessing3Description;

    [Header("UI")]
    public GameObject blessingsList;
    public GameObject cursesList;
    public GameObject startButton;
    public GameObject waveNumberText;
    public GameObject quitButton;

    [Header("Game Over")]
    public GameObject GameOverText;
    public GameObject GameOverTitle;

    //list of ranged weapons
    public List<RangeWeaponScript> rangedWeaponsToAdd = new List<RangeWeaponScript>();


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        currentGameState = GameState.Start;
        maxWavePoints = wavePoints;

        //disable the gameoverTitle
        GameOverTitle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //get the player position from the game objevt called player in 2D
        Vector2 playerPosition = GameObject.Find("Player").transform.position;
        
        if(currentGameState == GameState.Start)
        {
            //Disable the player movment script
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;
        }

        //if the gamestate changes to wave start the wave once
        if (currentGameState == GameState.Wave && !hasWaveStarted)
        {
            //give the player the max health
            PlayerStats.instance.health = PlayerStats.instance.maxHealth;
            shopUI.SetActive(false);
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = true;
            Debug.Log("Wave " + waveNumber + " has started");
            EnemyManager.instance.StartWave();
            hasWaveStarted = true;
            haveRolledBlessings = false;

            //update the wave number text
            waveNumberText.GetComponent<TextMeshProUGUI>().text = "Wave: " + waveNumber;
        }
        if(currentGameState == GameState.Shop)
        {
            hasWaveStarted = false;
            //turn on the shop UI in the canvas
            shopUI.SetActive(true);

            if (!haveRolledBlessings)
            {

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
                    
                haveRolledBlessings = true;
            }

        }

        if (currentGameState == GameState.GameOver)
        {
            //disable the player movement script
            GameObject.Find("Player").GetComponent<PlayerMovement>().enabled = false;

            //display the game over text
            GameOverTitle.SetActive(true);

            //Change the Game Over text to display the wave number and how many curses the player had accumulated
            GameOverText.GetComponent<TextMeshProUGUI>().text = "Wave: " + waveNumber + "\nCurses: " + PlayerStats.instance.curses.Count;


        }
        
    }

        //function that passes the name of the blessingTier1 text
        public void BuyBlessing1()
        {
            //call the activate blessing function from the blessing and curses script
            BlessingAndCursesScript.instance.ActivateBlessing(blessing1.GetComponent<TextMeshProUGUI>().text);

            //disable the shop UI
            shopUI.SetActive(false);

            //add 100 points to the max wave points
            maxWavePoints += 100;
            wavePoints = maxWavePoints;

            UpdateUI();

            //change the gamestate to wave
            currentGameState = GameState.Wave;
        }

        public void BuyBlessing2()
        {
            BlessingAndCursesScript.instance.ActivateBlessing(blessing2.GetComponent<TextMeshProUGUI>().text);

            //disable the shop UI
            shopUI.SetActive(false);

            //add 100 points to the max wave points
            maxWavePoints += 100;
            wavePoints = maxWavePoints;

            UpdateUI();

            //change the gamestate to wave
            currentGameState = GameState.Wave;
        }

        public void BuyBlessing3()
        {
            BlessingAndCursesScript.instance.ActivateBlessing(blessing3.GetComponent<TextMeshProUGUI>().text);

            //disable the shop UI
            shopUI.SetActive(false);

            //add 100 points to the max wave points
            maxWavePoints += 100;
            wavePoints = maxWavePoints;

            UpdateUI();

            //change the gamestate to wave
            currentGameState = GameState.Wave;
        }

        public void UpdateUI()
        {
            //set the blessings text in the UI
            foreach (string blessing in PlayerStats.instance.blessings)
            {
                //Display the blessing in the UI
                blessingsList.GetComponent<TextMeshProUGUI>().text += blessing + "\n" + "\n"; 
            }

            //same with curses
            foreach (string curse in PlayerStats.instance.curses)
            {
                //Display the curse in the UI
                cursesList.GetComponent<TextMeshProUGUI>().text += curse + "\n" + "\n"; 
            }
        }

        public void StartWave()
        {
            //change the gamestate to wave
            currentGameState = GameState.Wave;

            //disable the start button
            startButton.SetActive(false);
            
        }

        public void RestartGame(){
            //reload the scene
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }

        public void QuitGame()
        {
            //quit the game
            Application.Quit();
        }
    
}
