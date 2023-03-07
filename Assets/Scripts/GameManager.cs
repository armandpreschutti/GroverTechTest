
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
    public float currentChest;
    public float currentPrize;
    
    
    public float[] remaingChests = new float[8];
    

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
        currentPrize = multiplierHandler.currentMultiplier * changeDenomination.currentDenomination;
        
    }
    public void SetChests()
    {
        Debug.Log(currentPrize);
        if(currentPrize == 0)
        {
            Debug.Log("pooper");
        }
        if(currentPrize >0)
        {
            for (int i = 0; i < remaingChests.Length; i++)
            {
                
                currentChest = Mathf.Round(Random.Range(0, currentPrize) * 20f) / 20f; 
                currentPrize = currentPrize - currentChest;
                remaingChests[i] = currentChest;
               
            }
        }
        Debug.Log(remaingChests);


    }
}
