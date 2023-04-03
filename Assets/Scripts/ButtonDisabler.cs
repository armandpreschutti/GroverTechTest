using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.LowLevel;
using UnityEngine.UI;


public class ButtonDisabler : MonoBehaviour
{
    private GameManager gameManager;
    private GameObject playButton;
    private GameObject increaseButton;
    private GameObject decreaseButton;

    public GameObject[] chestButtons;
    public Color disableColor;
    public Color enableColor;

    /// <summary>
    /// On start, this function sets all the needed components for gameplay to a variable.
    /// </summary>
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        increaseButton = GameObject.FindGameObjectWithTag("AddDenominationButton");
        decreaseButton = GameObject.FindGameObjectWithTag("SubtractDenominationButton");
        playButton = GameObject.FindGameObjectWithTag("PlayButton");
    }

    public void DisableButton(GameObject button)
    {
        button.GetComponent<SpriteRenderer>().color = disableColor;
        button.GetComponent<BoxCollider>().enabled = false;

    }

    public void EnableButton(GameObject button)
    {
        button.GetComponent<SpriteRenderer>().color = enableColor;
        button.GetComponent<BoxCollider>().enabled = true;
    }

    /// <summary>
    /// When called, this function disables both denomination buttons
    /// </summary>
    public void DisableDenominationButtons()
    {
        DisableButton(increaseButton);
        DisableButton(decreaseButton);
    }

    /// <summary>
    /// When called, this function enables both denomination buttons
    /// </summary>
    public void EnableDenominationButtons()
    {
        EnableButton(increaseButton);
        EnableButton(decreaseButton);
    }

    /// <summary>
    /// When called, this function disables the play button
    /// </summary>
    public void DisablePlayButton()
    {
       DisableButton(playButton);
    }

    /// <summary>
    /// When called, this function enables the play button
    /// </summary>
    public void EnablePlayButton()
    {
        EnableButton(playButton);
    }

    /// <summary>
    /// This function is called at the start of every round and sets all the buttons to the appropriate state.
    /// </summary>
    public void StartGame()
    { 
        DisableDenominationButtons();
        DisablePlayButton();        
    }

    /// <summary>
    /// This function is called at the endof every round and sets all the buttons to the appropriate state.
    /// </summary>
    public void EndGame()
    {
        EnableDenominationButtons();
        EnablePlayButton();
    }

}
