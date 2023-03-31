using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    public GameManager gameManager;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    void Update()
    {
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.collider.gameObject.CompareTag("PlayButton"))
                {
                    gameManager.StartGame();

                }
                else if (hit.collider.gameObject.CompareTag("AddDenominationButton"))
                {
                    gameManager.changeDenomination.IncreaseDenomination();
                }
                else if (hit.collider.gameObject.CompareTag("SubtractDenominationButton"))
                {
                    gameManager.changeDenomination.DecreaseDenomination();

                }
                else if (hit.collider.gameObject.CompareTag("ChestButton"))
                {
                    if (!hit.collider.gameObject.GetComponent<ChestHandler>().chestOpened && !gameManager.isPooper)
                    {
                        hit.collider.gameObject.GetComponent<ChestHandler>().SelectChest();
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.collider.gameObject.CompareTag("ChestButton") && !gameManager.isPooper && gameManager.roundStarted)
                {
                    if (!hit.collider.gameObject.GetComponent<ChestHandler>().chestOpened)
                    {
                        hit.collider.gameObject.GetComponent<ChestHandler>().OpenChest();
                    }
                }
                else
                {
                    hit.collider.gameObject.GetComponent<ChestHandler>().ResetChest();
                }
            }

        }
    }
}
