using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LastGameHandler : MonoBehaviour
{
    public float lastGamePrize;
    public Text lastGamePrizeText;

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
