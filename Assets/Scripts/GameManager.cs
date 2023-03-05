using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ChangeDenomination changeDenomination;
    public ButtonDisabler buttonDisabler;
    public BalanceHandler balanceHandler;
    public LastGameHandler lastGameHandler;
    
    

    private void Start()
    {
        buttonDisabler.DisableTreasureButtons();
    }
    public void PlayGame()
    {
        buttonDisabler.DisableDenominationButtons();
        balanceHandler.DecreaseBalance(changeDenomination.currentDenomination);
        balanceHandler.UpdateBalanceText();
        lastGameHandler.ResetLastPrize();
        buttonDisabler.EnableTreasureButtons();
    }

}
