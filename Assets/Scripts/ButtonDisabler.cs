using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonDisabler : MonoBehaviour
{
    public Button playButton;
    public Button increaseButton;
    public Button decreaseButton;   

    public void DisableButtons()
    {
        playButton.interactable= false;
        increaseButton.interactable= false;
        decreaseButton.interactable= false; 
    }
    public void EnableButtons()
    {
        playButton.interactable= true;
        increaseButton.interactable= true;
        decreaseButton.interactable= true;
    }
}
