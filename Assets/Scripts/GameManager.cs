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
    
    public float[] chests;
    

    private void Start()
    {
        buttonDisabler.DisableTreasureButtons();
        buttonDisabler.chestButtons.SetActive(false);

    }
    public void PlayGame()
    {
        buttonDisabler.DisableDenominationButtons();
        balanceHandler.DecreaseBalance(changeDenomination.currentDenomination);
        balanceHandler.UpdateBalanceText();
        lastGameHandler.ResetLastPrize();
        buttonDisabler.EnableTreasureButtons();
        buttonDisabler.chestButtons.SetActive(true);
        SetWinAmount();
        SetChests();
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
}
