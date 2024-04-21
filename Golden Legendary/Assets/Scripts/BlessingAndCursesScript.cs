using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BlessingAndCursesScript : MonoBehaviour
{
    public static BlessingAndCursesScript instance;
    public List<Blessings> blessings = new List<Blessings>();
    public List<Curses> curses = new List<Curses>();

    //list with weapons
    public List<RangeWeaponScript> rangedWeapons = new List<RangeWeaponScript>();
    public List<MeleeWeaponScript> meleeWeapons = new List<MeleeWeaponScript>();


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }




    [System.Serializable]
    public class Blessings
    {
        public string blessingName;
        public int blessingTier;
        public string blessingDescription;
    }

    [System.Serializable]
    public class Curses
    {
        public string curseName;
        public int curseTier;
        public string curseDescription;
    }

    //function to get a random tier 1 blessing from the list
    public Blessings GetRandomTier1Blessing()
    {
        List<Blessings> tier1Blessings = new List<Blessings>();
        foreach (Blessings blessing in blessings)
        {
            if (blessing.blessingTier == 1)
            {
                tier1Blessings.Add(blessing);
            }
        }
        return tier1Blessings[Random.Range(0, tier1Blessings.Count)];
    }

    //function to get a random tier 2 blessing from the list
    public Blessings GetRandomTier2Blessing()
    {
        List<Blessings> tier2Blessings = new List<Blessings>();
        foreach (Blessings blessing in blessings)
        {
            if (blessing.blessingTier == 2)
            {
                tier2Blessings.Add(blessing);
            }
        }
        return tier2Blessings[Random.Range(0, tier2Blessings.Count)];
    }

    //function to get a random tier 3 blessing from the list
    public Blessings GetRandomTier3Blessing()
    {
        List<Blessings> tier3Blessings = new List<Blessings>();
        foreach (Blessings blessing in blessings)
        {
            if (blessing.blessingTier == 3)
            {
                tier3Blessings.Add(blessing);
            }
        }
        return tier3Blessings[Random.Range(0, tier3Blessings.Count)];
    }


    public void ActivateBlessing(string blessingName)
    {
        Debug.Log(blessingName);
        if(blessingName == "Healing Touch"){
            ActivateHealingTouch();
        }

        if(blessingName == "Glory of Artemis"){
            ActivateGoryOfArtemis();
        }

        if(blessingName == "Spear of Achilles"){
            ActivateSpearOfAchilles();
        }

        if(blessingName == "Cool Spirit"){
            // 20% + Health
            ActivateCoolSpirit();
        }

        if(blessingName == "Elixier of Carwyn"){
            //Speed +2
            ActivateElixierOfCarwyn();
        }

        if(blessingName == "Flame of Isadora"){
            //Explosions!
            ActivateFlameOfIsadora();
        }

        if(blessingName == "Breath of Kailani"){
            //Chaining projectiles
            ActivateBreathOfKailani();
        }

        if(blessingName == "Blessing of Ellisia"){
            //Homing Projectiles
            ActivateBlessingOfEllisia();
        }

        if(blessingName == "Will of Medusa"){
            //Piercing Projectiles
            ActivateWillOfMedusa();
        }

        if(blessingName == "Strength of Ares"){
            //+ 15% Damage
            ActivateStrengthOfAres();
        }

        if(blessingName == "Strength of Zeus"){
            //+ 25% Damage
            ActivateStrengthOfZeus();
        }
    }

    public void ActivateCurse(string curseName)
    {
        Debug.Log(curseName);
        if(curseName == "Encumberment"){
            ActivateEncumberment();
        }

        if(curseName == "Jinx og Anxiety"){
            // - 20% health
            ActivateJinxOfAnxiety();
        }

        if(curseName == "Curse of Doom"){
            // - 10% damage
            ActivateCurseOfDoom();
        }

        if(curseName == "The Death Bell"){
            //  10% - health
            ActivateTheDeathBell();
        }

        if(curseName == "Limp limb Vex"){
            //15% slower movement
            ActivateLimpLimbVex();
        }
    }


//ACTIVATE BLESSINGS
    public void ActivateHealingTouch()
    {
        Debug.Log("Healing Touch Activated");

        //give the player + 5 health
        PlayerStats.instance.maxHealth += 20;

        //add the blessing to the player stats list of blessings
        PlayerStats.instance.blessings.Add("Healing Touch");

        //Get appropriate amount of curses
        AddCurse(1);
    }

    public void ActivateGoryOfArtemis()
    {
        Debug.Log("Glory of Artemis Activated");

        //add the blessing to the player stats list of blessings
        PlayerStats.instance.blessings.Add("Glory of Artemis");

        //add the first element of the ranged weapons list to the current ranged weapons list of the players ranged weapons in the game manager
        GameManager.instance.rangedWeaponsToAdd.Add(rangedWeapons[0]);
        
        //Get appropriate amount of curses
        AddCurse(3);
    }

    public void ActivateSpearOfAchilles()
    {
        Debug.Log("Spear of Achilles Activated");

        //add the blessing to the player stats list of blessings
        PlayerStats.instance.blessings.Add("Spear of Achilles");

        //add the first element of the melee weapons list to the current melee weapons list of the player
        PlayerStats.instance.currentMeleeWeapons.Add(meleeWeapons[0]);
        //Get appropriate amount of curses
        AddCurse(3);
    }

    public void ActivateCoolSpirit()
    {
        Debug.Log("Cool Spirit Activated");

        //give the player + 20% health as float
        PlayerStats.instance.maxHealth += (PlayerStats.instance.maxHealth * 0.2f);
        
        //add the blessing to the player stats list of blessings
        PlayerStats.instance.blessings.Add("Cool Spirit");

        //Get appropriate amount of curses
        AddCurse(2);
    }

    public void ActivateElixierOfCarwyn()
    {
        Debug.Log("Elixier of Carwyn Activated");

        //give the player + 2 speed
        PlayerStats.instance.speed += 2;

        //add the blessing to the player stats list of blessings
        PlayerStats.instance.blessings.Add("Elixier of Carwyn");

        //Get appropriate amount of curses
        AddCurse(2);
    }

    public void ActivateFlameOfIsadora()
    {
        Debug.Log("Flame of Isadora Activated");

        //add the blessing to the player stats list of blessings
        PlayerStats.instance.blessings.Add("Flame of Isadora");

        //activate explosion in the players ranged weapons
        foreach (RangeWeaponScript weapon in PlayerStats.instance.currentRangedWeapons)
        {
            weapon.explosive = true;
        }
        //Get appropriate amount of curses
        AddCurse(3);
    }

    public void ActivateBreathOfKailani()
    {
        Debug.Log("Breath of Kailani Activated");

        //add the blessing to the player stats list of blessings
        PlayerStats.instance.blessings.Add("Breath of Kailani");

        //activate chaining in the players ranged weapons
        foreach (RangeWeaponScript weapon in PlayerStats.instance.currentRangedWeapons)
        {
            weapon.chaining = true;
        }
        //Get appropriate amount of curses
        AddCurse(3);
    }

    public void ActivateBlessingOfEllisia()
    {
        Debug.Log("Blessing of Ellisia Activated");

        //add the blessing to the player stats list of blessings
        PlayerStats.instance.blessings.Add("Blessing of Ellisia");

        //activate homing in the players ranged weapons
        foreach (RangeWeaponScript weapon in PlayerStats.instance.currentRangedWeapons)
        {
            weapon.hooming = true;
        }
        //Get appropriate amount of curses
        AddCurse(1);
    }

    public void ActivateWillOfMedusa()
    {
        Debug.Log("Will of Medusa Activated");

        //add the blessing to the player stats list of blessings
        PlayerStats.instance.blessings.Add("Will of Medusa");

        //activate piercing in the players ranged weapons
        foreach (RangeWeaponScript weapon in PlayerStats.instance.currentRangedWeapons)
        {
            weapon.piercing = true;
        }
        //Get appropriate amount of curses
        AddCurse(3);
    }

    public void ActivateStrengthOfAres()
    {
        Debug.Log("Strength of Ares Activated");

        //give the player + 15% damage
        PlayerStats.instance.damage += (PlayerStats.instance.damage * 0.15f);

        //add the blessing to the player stats list of blessings
        PlayerStats.instance.blessings.Add("Strength of Ares");

        //Get appropriate amount of curses
        AddCurse(1);
    }

    public void ActivateStrengthOfZeus()
    {
        Debug.Log("Strength of Zeus Activated");

        //give the player + 25% damage
        PlayerStats.instance.damage += (PlayerStats.instance.damage * 0.25f);

        //add the blessing to the player stats list of blessings
        PlayerStats.instance.blessings.Add("Strength of Zeus");

        //Get appropriate amount of curses
        AddCurse(2);
    }

    //ACTIVATE CURSES
    public void AddCurse(int amount)
    {
        Debug.Log("Adding " + amount + " curses");

        List<Curses> cursesToAdd = new List<Curses>();

        //add a curse to the player stats for each amount then minus -1 from the amount
        for (int i = 0; i < amount; i++)
        {
            //add a random curse to the list of curses to add
            int randomIndex = Random.Range(0, curses.Count);
            cursesToAdd.Add(curses[randomIndex]);

            //activate the curse
            ActivateCurse(curses[randomIndex].curseName);
        }

    }

    public void ActivateEncumberment()
    {
        bool encumberment = true;
        Debug.Log("Encumberment Activated");

        if(encumberment == true)
        {
            //give the player - 1 speed
            PlayerStats.instance.speed -= 1;

            //add the curse to the player stats list of curses
            PlayerStats.instance.curses.Add("Encumberment");
            encumberment = false;
        }
    }

    public void ActivateJinxOfAnxiety()
    {
        bool jinxOfAnxiety = true;
        Debug.Log("Jinx of Anxiety Activated");

        if(jinxOfAnxiety == true)
        {
            //give the player - 20% health
            PlayerStats.instance.maxHealth -= (PlayerStats.instance.maxHealth * 0.2f);

            //add the curse to the player stats list of curses
            PlayerStats.instance.curses.Add("Jinx of Anxiety");
            jinxOfAnxiety = false;
        }
    }

    public void ActivateCurseOfDoom()
    {
        bool curseOfDoom = true;
        Debug.Log("Curse of Doom Activated");

        if(curseOfDoom == true)
        {
            //give the player - 10% damage
            PlayerStats.instance.damage -= (PlayerStats.instance.damage * 0.1f);

            //add the curse to the player stats list of curses
            PlayerStats.instance.curses.Add("Curse of Doom");
            curseOfDoom = false;
        }
    }

    public void ActivateTheDeathBell()
    {
        bool theDeathBell = true;
        Debug.Log("The Death Bell Activated");

        if(theDeathBell == true)
        {
            //give the player - 10% health
            PlayerStats.instance.maxHealth -= (PlayerStats.instance.maxHealth * 0.1f);

            //add the curse to the player stats list of curses
            PlayerStats.instance.curses.Add("The Death Bell");
            theDeathBell = false;
        }
    }

    public void ActivateLimpLimbVex()
    {
        bool limpLimbVex = true;
        Debug.Log("Limp Limb Vex Activated");

        if(limpLimbVex == true)
        {
            //give the player - 15% speed
            PlayerStats.instance.speed -= 1.5f;

            //add the curse to the player stats list of curses
            PlayerStats.instance.curses.Add("Limp Limb Vex");
            limpLimbVex = false;
        }
    }

    

}
