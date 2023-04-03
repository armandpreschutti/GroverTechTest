using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BalanceHandler : MonoBehaviour
{
    private GameManager gameManager;

    public TextMeshPro balanceText;
    public float currentBalance;

    /// <summary>
    /// On start, this function sets all the needed components for gameplay to a variable and sets the current balance text.
    /// </summary>
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        UpdateBalanceText();
    }

    /// <summary>
    /// When called, this function sets the balnce text to the current balance.
    /// </summary>
    public void UpdateBalanceText()
    {
        balanceText.text = currentBalance.ToString("C");
    }

    /// <summary>
    /// When called, this function decreases the balance by a certain amount.
    /// </summary>
    /// <param name="amount">The amount to subtract from balance</param>
    public void IncreaseBalance(float amount)
    {
        currentBalance += amount;   
    }

    /// <summary>
    /// When called, this function increases the balance by a certain amount.
    /// </summary>
    /// <param name="amount">The amount to add to balance</param>
    public void DecreaseBalance(float amount)
    {
        currentBalance -= amount;
    }

    /// <summary>
    /// Called when the round begins.
    /// </summary>
    public void StartGame()
    {
        // Subtract the current denomination from balance.
        DecreaseBalance(gameManager.changeDenomination.currentDenomination);

        // Update the balance text.
        UpdateBalanceText();
    }

    /// <summary>
    /// Called when the round ends.
    /// </summary>
    public void EndGame()
    {
        // Add the prize to the current balance.
        IncreaseBalance(gameManager.lastGameHandler.lastGamePrize);

        // Update the balance text.
        UpdateBalanceText();
    }
}
