using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDenomination : MonoBehaviour
{

    public Text currentDenominationText;  
    public float currentDenomination = 0.25f;

    /// <summary>
    /// On start, this function makes the denomination .25 by default, then updates the denomination text to match.
    /// </summary>
    /// 
    public void Start()
    { 
        currentDenomination = .25f;
        UpdateDenominationText();
    }

    /// <summary>
    /// This function, when called, increaeses the denomination amount by a specific interval depending on the current denomination
    /// </summary>
    public void IncreaseDenomination()
    {
        if(currentDenomination == .25f)
        {
            currentDenomination = .5f;
            UpdateDenominationText();
        }
        else if (currentDenomination == .5f)
        {
            currentDenomination = 1f;
            UpdateDenominationText();
        }
        else if (currentDenomination == 1f)
        {
            currentDenomination = 5f;
            UpdateDenominationText();
        }
    }

    /// <summary>
    /// This function, when called, decreases the denomination amount by a specific interval depending on the current denomination
    /// </summary>
    public void DecreaseDenomination()
    {
        if (currentDenomination == .5f)
        {
            currentDenomination = .25f;
            UpdateDenominationText();
        }
        else if (currentDenomination == 1f)
        {
            currentDenomination = .5f;
            UpdateDenominationText();
        }
        else if (currentDenomination == 5f)
        {
            currentDenomination = 1f;
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
