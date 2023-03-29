using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

using TMPro;

public class GameManager : MonoBehaviour
{
    public ChangeDenomination changeDenomination;
    public ButtonDisabler buttonDisabler;
    public BalanceHandler balanceHandler;
    public LastGameHandler lastGameHandler;
    public MultiplierHandler multiplierHandler;
    public AudioHandler audioHandler;
    public ChestHandler[] chestsToSet;

    public int chestNumber;
    public int chestAmount;
    public float totalPrize;
    public float remainingPrize;
    public int remainingChests;
    public bool isPooper;
    public float[] chests;
 

    /// <summary>
    /// On start, this function sets all the needed components for gameplay to a variable.
    /// </summary>
    private void Start()
    {
        changeDenomination = GetComponent<ChangeDenomination>();
        balanceHandler = GetComponent<BalanceHandler>();
        buttonDisabler= GetComponent<ButtonDisabler>();
        lastGameHandler= GetComponent<LastGameHandler>();
        multiplierHandler= GetComponent<MultiplierHandler>();
        audioHandler= GetComponent<AudioHandler>();
    }

    /// <summary>
    /// When called, this function starts the bonus round.
    /// </summary>
    public void PlayGame()
    {
        // Checks to see if there is enough money to play. If not, the game will not start.
        if(balanceHandler.currentBalance <= 0 || changeDenomination.currentDenomination > balanceHandler.currentBalance)
        {
            // Play downbeat SFX.
            audioHandler.PlayChestCloseSFX();
            return;
        }
        
        // Play the start game SFX.
        audioHandler.PlayStartGameSFX();

        // Resets the pooper from the previous round.
        isPooper = false;

        // Sets the balance for round
        balanceHandler.PlayGame();
        
        // Sets the buttons state for the round.
        buttonDisabler.PlayGame();

        // Resets the last round prize to 0 
        lastGameHandler.ResetLastPrize();
        
        // Sets the win amount for this round.
        SetRoundPrize();

        // Sets the prize amount of each chest.
        SetChests();
    }

    /// <summary>
    /// When called, this function ends the bonus round.
    /// </summary>
    public void EndGame()
    {
        // Resets all the chest to the default state.
        chestsToSet = FindObjectsOfType<ChestHandler>();
        foreach (ChestHandler chest in chestsToSet)
        {
            chest.ResetChest();
        }

        // Resets the buttons to their default state.
        buttonDisabler.EndGame();

        // Adds the prize from this round to the current balance.
        balanceHandler.EndGame();

        // Reset the current chest number.
        chestNumber = 0;

        // Set this chest to be a "pooper"
        isPooper = true;

       
    }

    // When called, this function sets the total prize for the current round.
    public void SetRoundPrize()
    {
        // Sets the multiplier for the round.
        multiplierHandler.PickMultiplier();

        // Sets the prize for this round by multiplying the multiplier by the current denomination.
        totalPrize = multiplierHandler.currentMultiplier * changeDenomination.currentDenomination;
    }

    /// <summary>
    /// When called, this function sets the value of each chest for the round.
    /// </summary>
    public void SetChests()
    {
        // Set the remaining amount of prize to be distributed by dividing the total prize by .05.
        remainingPrize = totalPrize/.05f;

        // Create a new empty array with 8 elements.
        chests = new float[8];

        // Check to see if the prize is not a "pooper".
        if (remainingPrize > 0)
        {
            // Run through each element in the "chests" array.
            for (int i = 0; i < remainingChests; i++)
            {
                // Get the value of the current element in the chests array.
                chestAmount = Mathf.RoundToInt(Random.Range(1f, remainingPrize));

                // Break the for loop if there is no more prize to be distributed.
                if (remainingPrize <= 0)
                {
                    return;
                }

                else
                {
                    // Distribute the remaing prize to the last chest if pooper is next.
                    if (i == 7)
                    {
                        // Set the value of the current chest to the value of the reamining prize and multiply by .05.
                        chests[i] = remainingPrize * .05f;
                    }

                    else
                    {
                        // Set the value of the current chest and multiply by .05.
                        chests[i] = chestAmount * .05f;
                        
                        // subtract the the value of the chest from the remaining prize amount.
                        remainingPrize = remainingPrize - chestAmount;
                    }
                }
            }
        } 
    }

    /// <summary>
    /// Called whenever a chest button in pressed, this function take the amount of the selected chest and distributes it to the player.
    /// </summary>
    /// <param name="chestText">The chest text to be changed</param>
    public void DistributeChestPrize(TextMeshPro chestText)
    {
        // Check to see if there are any empty chest remaining and that the chest is not a "pooper".
        if(chestNumber < remainingChests && chests[chestNumber] != 0)
        {
            // Set the chest value text to the value of the chest.
            chestText.text = chests[chestNumber].ToString("C");

            // Add the value of the chest to the last game won value.
            lastGameHandler.AddToPrize(chests[chestNumber]);

            // Increment to the next chest in the "chests" array.
            chestNumber++;
        }

        else
        {
            // End this round.
            EndGame();          
        }
    }
    
}
