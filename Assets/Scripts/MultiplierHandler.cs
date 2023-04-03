using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierHandler : MonoBehaviour
{
    private GameManager gameManager;
    private int[] multiplierOdds= new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3};
    private int[] commonMultiplierValues = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
    private int[] uncommonMultiplierValues = new int[] {12, 16, 24, 32, 48, 64};
    private int[] rareMultiplierValues = new int[] { 100, 200, 300, 400, 500 };
    private int tierIndex;
    private int multiplierIndex;
    private int commonIndex;
    private int uncommonIndex;
    private int rareIndex;

    public int currentMultiplier;

    /// <summary>
    /// On start, this function sets all the needed components for gameplay to a variable.
    /// </summary>
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    
    /// <summary>
    /// When called, this function sets the multiplier for the current round.
    /// </summary>
    public void PickMultiplier()
    {
        // Get a random number to pick the type of multiplier
        tierIndex = Random.Range(0, multiplierOdds.Length);

        // Get a random multiplier from the multiplier odds array.
        multiplierIndex = multiplierOdds[tierIndex];

        if (multiplierIndex == 0)
        {
            // Set the current multiplier to be a "pooper".
            currentMultiplier = 0;
        }
        else if(multiplierIndex == 1)
        {
            // Get a random number to pick the value of multiplier
            commonIndex = Random.Range(0, commonMultiplierValues.Length);

            // Set the multiplier based on the position in array using the index.
            currentMultiplier = commonMultiplierValues[commonIndex];
        }
        else if(multiplierIndex == 2)
        {
            // Get a random number to pick the value of multiplier
            uncommonIndex = Random.Range(0, uncommonMultiplierValues.Length);

            // Set the multiplier based on the position in array using the index.
            currentMultiplier = uncommonMultiplierValues[uncommonIndex];
        }
        else if(multiplierIndex == 3)
        {
            // Get a random number to pick the value of multiplier
            rareIndex = Random.Range(0, rareMultiplierValues.Length);

            // Set the multiplier based on the position in array using the index.
            currentMultiplier = rareMultiplierValues[rareIndex];
        }
    }
}
