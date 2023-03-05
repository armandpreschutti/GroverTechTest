using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public ChangeDenomination changeDenomination;
    public ButtonDisabler buttonDisabler;

    public Button playButton;
    public float CurrentBet;

    public void PlayGame()
    {
        
    }
    public void Tester()
    {
        Debug.Log(CurrentBet);
    }
}
