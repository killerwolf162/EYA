using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Status_Checklist : MonoBehaviour
{
    // This script is used to store all stats related to in-game choices.
    // Ranging from relationschip points to certain checks regarding events. e.a did the player hold the first petition with the peasants, and if yes what was his verdict?

    //public UnityEvent

    //relationschip points
    public int karlomanRelation = 5;
    public int commonerRelation = 2;
    public int nobleRelation = 0;

    //event checks
    public bool heldFirstCourt;
    public bool gaveCalfToGerald;
    public bool gaveCalfToBethany;
    public bool increasedDefenceBudget;

    public void IncreaseKarlomanRelation()
    {
        karlomanRelation += 1;
    }
    public void DecreaseKarlomanRelation()
    {
        karlomanRelation -= 1;
    }
    public void IncreaseCommonerRelation()
    {
        commonerRelation += 1;
    }
    public void DecereaseCommonerRelation()
    {
        commonerRelation += 1;
    }
    public void IncreaseNobleRealtion()
    {
        nobleRelation += 1;
    }
    public void DecreaseNobleRelation()
    {
        nobleRelation += 1;
    }
    public void HeldFirstCourt()
    {
        heldFirstCourt = true;
    }
    public void GaveCalfToGerald()
    {
        gaveCalfToGerald = true;
        gaveCalfToBethany = false;
    }
    public void GaveCalfToBethany()
    {
        gaveCalfToGerald = false;
        gaveCalfToBethany = true;
    }
    public void IncreasedDefeceBudget()
    {
        increasedDefenceBudget = true;
    }
}
