using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ChangeDenomination changeDenomination;
    public ButtonDisabler buttonDisabler;
    public BalanceHandler balanceHandler;
    public LastGameHandler lastGameHandler;
    public MultiplierHandler multiplierHandler;
    public int chestNumber;
    public int chestAmount;
    public float totalPrize;
    public float remainingPrize;
    public int remainingChests;
    public bool isPooper;
    public float[] chests;
    public ChestHandler[] chestsToSet;

    // Call the "MyFunction" function on each object

    private void Start()
    {
        buttonDisabler.DisableTreasureButtons();
        buttonDisabler.chestButtons.SetActive(false);
        chestsToSet = FindObjectsOfType<ChestHandler>();
        
    }
    public void PlayGame()
    {
        if(balanceHandler.currentBalance <= 0)
        {
            return;
        }

        isPooper = false;
        balanceHandler.DecreaseBalance(changeDenomination.currentDenomination);
        balanceHandler.UpdateBalanceText();
        lastGameHandler.ResetLastPrize();
        buttonDisabler.DisableDenominationButtons();
        buttonDisabler.DisablePlayButton();
        buttonDisabler.chestButtons.SetActive(true);
        buttonDisabler.EnableTreasureButtons();
        SetWinAmount();
        SetChests();

    }
    public void EndGame()
    {
        buttonDisabler.EnableDenominationButtons();
        buttonDisabler.EnablePlayButton();
        buttonDisabler.DisableTreasureButtons();
        balanceHandler.IncreaseBalance(lastGameHandler.lastGamePrize);
        balanceHandler.UpdateBalanceText();
        chestsToSet = FindObjectsOfType<ChestHandler>();
        foreach (ChestHandler chest in chestsToSet)
        {
            chest.ResetChest();
        }

    }

    public void SetWinAmount()
    {
        multiplierHandler.PickMultiplier();
        totalPrize = multiplierHandler.currentMultiplier * changeDenomination.currentDenomination;
        

    }
    public void SetChests()
    {
        remainingPrize = totalPrize/.05f;
        chests = new float[8];

        if (remainingPrize > 0)
        {
            for (int i = 0; i < remainingChests; i++)
            {
                chestAmount = Mathf.RoundToInt(Random.Range(1f, remainingPrize));

                if (remainingPrize <= 0)
                {
                    
                    //buttonDisabler.DisableTreasureButtons();
                    return;
                }

                else
                {
                    if (i == 7)
                    {
                        
                        chests[i] = remainingPrize * .05f;
                    }

                    else
                    {
                        
                        chests[i] = chestAmount * .05f;
                        remainingPrize = remainingPrize - chestAmount;
                    }
                }
            }
        } 
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="chestText"></param>
    public void DistributeChestPrize(Text chestText)
    {
        if(chestNumber < remainingChests && chests[chestNumber] != 0)
        {
            chestText.text = chests[chestNumber].ToString("C");
            lastGameHandler.AddToPrize(chests[chestNumber]);
            chestNumber++;
        }

        else
        {
            isPooper = true;
            chestText.text = "Pooper";
            chestNumber = 0; 
            chestsToSet = FindObjectsOfType<ChestHandler>();
            buttonDisabler.EnableDenominationButtons();
            buttonDisabler.EnablePlayButton();
            buttonDisabler.DisableTreasureButtons();
            balanceHandler.IncreaseBalance(lastGameHandler.lastGamePrize);
            balanceHandler.UpdateBalanceText();
            foreach (ChestHandler chest in chestsToSet)
            {
                chest.ResetChest();
            }
            // EndGame();          
        }
    }
    
}
