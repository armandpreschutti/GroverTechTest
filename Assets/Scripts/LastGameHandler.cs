using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastGameHandler : MonoBehaviour
{
    public GameManager gameManager;

    public float lastGamePrize;
    public Text lastGamePrizeText;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void ResetLastPrize()
    {
        lastGamePrize = 0;
        lastGamePrizeText.text = lastGamePrize.ToString("C");
    }
    public void AddToPrize(float amount)
    {
        lastGamePrize+= amount;
        lastGamePrizeText.text = lastGamePrize.ToString("C");
    }
}
