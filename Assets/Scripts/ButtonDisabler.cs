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
    public Button treasure1;
    public Button treasure2;
    public Button treasure3;
    public Button treasure4;
    public Button treasure5;
    public Button treasure6;
    public Button treasure7;
    public Button treasure8;
    public Button treasure9;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void DisableDenominationButtons()
    {
        increaseButton.interactable= false;
        decreaseButton.interactable= false; 
    }

    public void EnableDenominationButtons()
    {
        increaseButton.interactable= true;
        decreaseButton.interactable= true;
    }

    public void DisableTreasureButtons()
    {
        treasure1.interactable= false;
        treasure2.interactable= false;
        treasure3.interactable= false;
        treasure4.interactable= false;
        treasure5.interactable= false;
        treasure6.interactable= false;
        treasure7.interactable= false;
        treasure8.interactable= false;
        treasure9.interactable= false;
    }

    public void EnableTreasureButtons()
    {
        treasure1.interactable = true;
        treasure2.interactable= true;
        treasure3.interactable= true;
        treasure4.interactable= true;
        treasure5.interactable= true;
        treasure6.interactable= true;
        treasure7.interactable= true;
        treasure8.interactable= true;
        treasure9.interactable= true;
    }
    public void DisablePlayBUtton()
    {
        playButton.interactable = false;
    }
    public void EnablePlayBUtton()
    {
        playButton.interactable = true;
    }
}
