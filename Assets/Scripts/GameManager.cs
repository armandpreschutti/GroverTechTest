using System;
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
    public float currentPrize;
    

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
    }
    public void SetWinAmount()
    {
        multiplierHandler.PickMultiplier();
        currentPrize = multiplierHandler.currentMultiplier * changeDenomination.currentDenomination;
        Debug.Log(currentPrize);
    }

}
