using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChangeDenomination : MonoBehaviour
{
    public bool useQuarter;
    public bool useHalf;
    public TextMeshPro currentDenominationText;  
    public float currentDenomination = 0.25f;
    public int currentIndex;
    public int[] denominations;


    /// <summary>
    /// On start, this function makes the denomination .25 by default, then updates the denomination text to match.
    /// </summary>
    /// 
    public void Start()
    {
        currentDenomination = denominations[0];
        UpdateDenominationText();
    }

    /// <summary>
    /// This function, when called, increaeses the denomination amount by a specific interval depending on the current denomination
    /// </summary>
    public void IncreaseDenomination()
    {
        if(currentIndex < denominations.Length - 1)
        {
            currentIndex += 1;
            currentDenomination = denominations[currentIndex];
            UpdateDenominationText();
        }
        else
        {
            return;
        }

    }

    /// <summary>
    /// This function, when called, decreases the denomination amount by a specific interval depending on the current denomination
    /// </summary>
    public void DecreaseDenomination()
    {
        if(currentIndex > 0)
        {
            currentIndex -= 1;
            currentDenomination = denominations[currentIndex];
            UpdateDenominationText();
        }
      
    }

    /// <summary>
    /// This function, when called, updated the denomination text to the current denomination.
    /// </summary>

    private void UpdateDenominationText()
    {
        currentDenominationText.text = currentDenomination.ToString("C");
    }
}
