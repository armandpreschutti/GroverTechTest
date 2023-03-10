using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonDisabler : MonoBehaviour
{
    public GameManager gameManager;

    public Button playButton;
    public Button increaseButton;
    public Button decreaseButton;
    public GameObject chestButtons;
    public Button chestButton1;
    public Button chestButton2;
    public Button chestButton3;
    public Button chestButton4;
    public Button chestButton5;
    public Button chestButton6;
    public Button chestButton7;
    public Button chestButton8;
    public Button chestButton9;

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
        increaseButton.interactable= false;
        decreaseButton.interactable= false; 
    }

    /// <summary>
    /// When called, this function enables both denomination buttons
    /// </summary>
    public void EnableDenominationButtons()
    {
        increaseButton.interactable= true;
        decreaseButton.interactable= true;
    }

    /// <summary>
    /// When called, this function disables all chest buttons
    /// </summary>

    public void DisableChestButtons()
    {
        chestButton1.interactable= false;
        chestButton2.interactable= false;
        chestButton3.interactable= false;
        chestButton4.interactable= false;
        chestButton5.interactable= false;
        chestButton6.interactable= false;
        chestButton7.interactable= false;
        chestButton8.interactable= false;
        chestButton9.interactable= false;
    }

    /// <summary>
    /// When called, this function enables all chest buttons
    /// </summary>
    public void EnableChestButtons()
    {
        chestButton1.interactable = true;
        chestButton2.interactable= true;
        chestButton3.interactable= true;
        chestButton4.interactable= true;
        chestButton5.interactable= true;
        chestButton6.interactable= true;
        chestButton7.interactable= true;
        chestButton8.interactable= true;
        chestButton9.interactable= true;
    }

    /// <summary>
    /// When called, this function disables the play button
    /// </summary>
    public void DisablePlayButton()
    {
        playButton.interactable = false;
    }

    /// <summary>
    /// When called, this function enables the play button
    /// </summary>
    public void EnablePlayButton()
    {
        playButton.interactable = true;
    }

    /// <summary>
    /// This function is called at the start of every round and sets all the buttons to the appropriate state.
    /// </summary>
    public void PlayGame()
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
        EnableDenominationButtons();
        EnablePlayButton();
        DisableChestButtons();
    }
}
