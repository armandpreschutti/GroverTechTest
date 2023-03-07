using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceHandler : MonoBehaviour
{
    public GameManager gameManager;

    public Text balanceText;
    public float currentBalance;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        currentBalance = 10.0f;
        UpdateBalanceText();
    }

    public void UpdateBalanceText()
    {
        balanceText.text = currentBalance.ToString("C");
    }
    public void IncreaseBalance(float amount)
    {
        currentBalance += amount;   
    }
    public void DecreaseBalance(float amount)
    {
        currentBalance -= amount;
    }
}
