using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ChestHandler : MonoBehaviour
{
    public GameManager gameManager;
    public Button thisButton;
    public Image thisImage;
    public Sprite closedSprite;
    public Sprite openSprite;
    public Text thisAmount;

    /// <summary>
    /// On start, this function sets all the needed components for gameplay to a variable.
    /// </summary>
    private void Start()
    {
        gameManager= FindObjectOfType<GameManager>();
        thisImage = GetComponent<Image>();
        thisButton= GetComponent<Button>();
        thisAmount = GetComponentInChildren<Text>();
    }

    /// <summary>
    /// Called whenever the player opens a chest
    /// </summary>
    public void OpenChest()
    {
        // Set the chest sprite to be in an open state.
        thisImage.sprite = openSprite;

        // Disable the button.
        thisButton.interactable = false;

        // Distribute the value of the chest.
        gameManager.DistributeChestPrize(thisAmount);

        // Check to see if chest is a "pooper".
        if (gameManager.isPooper)
        {
            // Do a shake animation if chest is a "pooper".
            transform.DOPunchPosition(new Vector3(40, 0, 0), .5f, 10, 1f);

            // Play upbeat SFX.
            gameManager.audioHandler.PlayChestCloseSFX();
        }
        else
        {
            // Do a pop animation if chest is not a "pooper".
            transform.DOPunchScale(Vector3.one * 1.5f, .25f);

            // Play downbeat SFX.
            gameManager.audioHandler.PlayChestOpenSFX();
        }
    }

    /// <summary>
    /// When called, this function resets the chests to their default state.
    /// </summary>
    public void ResetChest()
    {
        // Set the chest sprite to be in an closed state.
        thisImage.sprite = closedSprite;

        // Set the chest value text to be empty.
        thisAmount.text = "";
    }

    
}
