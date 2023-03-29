using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LastGameHandler : MonoBehaviour
{
    public GameManager gameManager;

    public float lastGamePrize;
    public TextMeshPro lastGamePrizeText;
    

    /// <summary>
    /// On start, this function sets all the needed components for gameplay to a variable.
    /// </summary>
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        ResetLastPrize();
    }

    /// <summary>
    /// When called, this function resets the last game won.
    /// </summary>
    public void ResetLastPrize()
    {
        // Set last game won to zero.
        lastGamePrize = 0;

        // Update last game won text.
        UpdateLastPrizeText();
    }

    /// <summary>
    /// When called, this function adds to the current prize for the round.
    /// </summary>
    /// <param name="amount">The amount to add to prize</param>
    public void AddToPrize(float amount)
    {
        // Add the parameter to the prize.
        lastGamePrize+= amount;

        // Update last game won text.
        UpdateLastPrizeText();
    }

    /// <summary>
    /// When called, this function updates the last game won text to the current prize.
    /// </summary>
    public void UpdateLastPrizeText()
    {
        lastGamePrizeText.text = lastGamePrize.ToString("C");
    }
}
