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


    private void Start()
    {
        gameManager= FindObjectOfType<GameManager>();
        thisImage = GetComponent<Image>();
        thisButton= GetComponent<Button>();
        thisAmount = GetComponentInChildren<Text>();
       
    }

    public void OpenChest()
    {
        thisImage.sprite = openSprite;
        thisButton.interactable = false;
        gameManager.DistributeChestPrize(thisAmount);
        if (gameManager.isPooper)
        {
            transform.DOPunchPosition(new Vector3(40, 0, 0), .5f, 10, 1f);
        }
        else
        {
            transform.DOPunchScale(Vector3.one * 1.5f, .25f);
        }
        
    }
    public void ResetChest()
    {
        thisImage.sprite = closedSprite;
        thisAmount.text = "";
    }

    
}
