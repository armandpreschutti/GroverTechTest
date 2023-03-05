using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeDenomination : MonoBehaviour
{
    public Text currentDenominationText;
    public GameManager gameManager;

    public float denominationIncrement = 0.25f;
    public float maxBet = 1.00f;
    public float minBet = .25f;    
    public float currentDenomination = 0.25f;

    public void Start()
    {
        currentDenomination = .25f;
        UpdateDenominationText();
    }

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

    private void UpdateDenominationText()
    {
        currentDenominationText.text = currentDenomination.ToString("C");

    }
}
