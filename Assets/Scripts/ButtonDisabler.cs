using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonDisabler : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject playButton;
    public GameObject increaseButton;
    public GameObject decreaseButton;
    public GameObject chestButtons;
    public GameObject chestButton1;
    public GameObject chestButton2;
    public GameObject chestButton3;
    public GameObject chestButton4;
    public GameObject chestButton5;
    public GameObject chestButton6;
    public GameObject chestButton7;
    public GameObject chestButton8;
    public GameObject chestButton9;


    /// <summary>
    /// On start, this function sets all the needed components for gameplay to a variable.
    /// </summary>
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    /// <summary>
    /// When called, this function disables both denomination buttons
    /// </summary>
    public void DisableDenominationButtons()
    {
        increaseButton.SetActive(false);
        decreaseButton.SetActive(false);
    }

    /// <summary>
    /// When called, this function enables both denomination buttons
    /// </summary>
    public void EnableDenominationButtons()
    {
        increaseButton.SetActive(true); 
        decreaseButton.SetActive(true);    
    }

    /// <summary>
    /// When called, this function disables all chest buttons
    /// </summary>

    public void DisableChestButtons()
    {
        
    }

    /// <summary>
    /// When called, this function enables all chest buttons
    /// </summary>
    public void EnableChestButtons()
    {
       
    }

    /// <summary>
    /// When called, this function disables the play button
    /// </summary>
    public void DisablePlayButton()
    {
       playButton.SetActive(false);
    }

    /// <summary>
    /// When called, this function enables the play button
    /// </summary>
    public void EnablePlayButton()
    {
        playButton.SetActive(true);
    }

    /// <summary>
    /// This function is called at the start of every round and sets all the buttons to the appropriate state.
    /// </summary>
    public void StartGame()
    {
        chestButtons.SetActive(true);
        DisableDenominationButtons();
        DisablePlayButton();        
        EnableChestButtons();
    }

    /// <summary>
    /// This function is called at the endof every round and sets all the buttons to the appropriate state.
    /// </summary>
    public void EndGame()
    {
        //chestButtons.SetActive(false);
        EnableDenominationButtons();
        EnablePlayButton();
        DisableChestButtons();
    }
}
