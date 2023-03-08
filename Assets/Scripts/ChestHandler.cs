using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChestHandler : MonoBehaviour
{
    public GameManager gameManager;
    public Button thisButton;
    public Image thisImage;
    public Sprite closedSprite;
    public Sprite openSprite;
    public Text thisAmount;
    public float chestValue;

    private void Start()
    {
        gameManager= FindObjectOfType<GameManager>();
        thisImage = GetComponent<Image>();
        thisButton= GetComponent<Button>();
        chestValue = Random.Range(.01f, 1f);
    }

    public void OpenChest()
    {
        thisImage.sprite = openSprite;
        thisButton.interactable = false;
        
    }
    
}
