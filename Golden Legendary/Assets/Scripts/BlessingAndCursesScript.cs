using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlessingAndCursesScript : MonoBehaviour
{
    public static BlessingAndCursesScript instance;
    public List<Blessings> blessings = new List<Blessings>();
    public List<Curses> curses = new List<Curses>();


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
        Debug.Log("Hejsa");
        if(blessingName == "Healing Touch"){
            ActivateHealingTouch();
        }



    }

    public void ActivateHealingTouch()
    {
        //give the player +5 health
        
        


    }
    

}
