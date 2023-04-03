using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class ChestHandler : MonoBehaviour
{
    private TextMeshPro thisAmount;
    private GameManager gameManager;
    private SpriteRenderer thisImage;
    private GameObject prizeDestination;

    public GameObject prizeItem;
    public Sprite closedSprite;
    public Sprite selectedSprite;
    public Sprite openSprite;
    public bool chestOpened;

    /// <summary>
    /// On start, this function sets all the needed components for gameplay to a variable.
    /// </summary>
    private void Start()
    {
        gameManager= FindObjectOfType<GameManager>();
        thisImage = GetComponent<SpriteRenderer>();
        thisAmount = GetComponentInChildren<TextMeshPro>();
        prizeDestination = GameObject.Find("PrizeDestination");
        Debug.Log(prizeDestination.transform.position);
    }
    
    /// <summary>
    /// When called, this function shows a slightly open chest to let the player "peak" inside.
    /// </summary>
    public void SelectChest()
    {
        thisImage.sprite = selectedSprite;
    }

    /// <summary>
    /// Called whenever the player opens a chest
    /// </summary>
    public void OpenChest()
    {
        // Set the chest sprite to be in an open state.
        thisImage.sprite = openSprite;

        // Set chest state to opened.
        chestOpened=true;

        // Distribute the value of the chest.
        gameManager.DistributeChestPrize(thisAmount);

        // Do a pop animation if chest is not a "pooper".
        transform.DOPunchScale(Vector3.one * 1.5f, .25f);

        // Check to see if chest is a "pooper".
        if (gameManager.isPooper)
        {
            /*// Do a shake animation if chest is a "pooper".
            transform.DOPunchPosition(new Vector3(1, 0, 0), .5f, 1, 1f);*/

            // Play upbeat SFX.
            gameManager.audioHandler.PlayChestCloseSFX();
            
        }
        else
        {
            // Play downbeat SFX.
            gameManager.audioHandler.PlayChestOpenSFX();

            // Create prize.
            GameObject prize = Instantiate(prizeItem, transform.position, Quaternion.identity);

            // Deliver prize. 
            prize.transform.DOMove(prizeDestination.transform.position, .5f);

            //Destory prize.
            Destroy(prize, .6f);
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

        // Set chest state to closed.
        chestOpened=false;       
    }

    /// <summary>
    /// When called, this function scales the chests to make them appear to be emerging from the sand.
    /// </summary>
    public void ShowChest()
    {
        transform.DOScale(.75f, .1f);
    }
}
