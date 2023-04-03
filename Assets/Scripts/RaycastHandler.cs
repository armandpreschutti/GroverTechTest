using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHandler : MonoBehaviour
{
    private GameManager gameManager;

    /// <summary>
    /// On start, this function sets all the needed components for gameplay to a variable.
    /// </summary>
    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    /// <summary>
    /// During each frame, this function checks whether the mouse button is clicked, then performed the appropriate action.
    /// </summary>
    void Update()
    {
        // Create raycast variable
        RaycastHit hit;

        // Check if button is pressed down.
        if (Input.GetMouseButtonDown(0))
        {
            // Create raycast from camera to mouse and output the result.
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                // Check if raycast hit is on the play button.
                if (hit.collider.gameObject.CompareTag("PlayButton"))
                {
                    // Start the round.
                    gameManager.StartGame();
                }
                // Check if raycast hit is on the positive denomination button.
                else if (hit.collider.gameObject.CompareTag("AddDenominationButton"))
                {
                    // Increase denomination amount.
                    gameManager.changeDenomination.IncreaseDenomination();
                }

                // Check if raycast hit is on the negative denomination button.
                else if (hit.collider.gameObject.CompareTag("SubtractDenominationButton"))
                {
                    // Decrease denomination amount.
                    gameManager.changeDenomination.DecreaseDenomination();

                }

                // Check if raycast hit is on a chest button.
                else if (hit.collider.gameObject.CompareTag("ChestButton"))
                {
                    // Check if the chest is already opened and is not a pooper.
                    if (!hit.collider.gameObject.GetComponent<ChestHandler>().chestOpened && !gameManager.isPooper)
                    {
                        // Select this chest.
                        hit.collider.gameObject.GetComponent<ChestHandler>().SelectChest();
                    }
                }
                else
                {
                    // Return if not applicable.
                    return;
                }
            }
        }

        // Check if button is presses up.
        if (Input.GetMouseButtonUp(0))
        {
            // Create raycast from camera to mouse and output the result.
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                // Check if the raycast is on a chest button and that it is not pooper.
                if (hit.collider.gameObject.CompareTag("ChestButton") && !gameManager.isPooper)
                {
                    // Check if the chest is not opened and that the round has started.
                    if (!hit.collider.gameObject.GetComponent<ChestHandler>().chestOpened && gameManager.roundStarted)
                    {
                        // Open this chest.
                        hit.collider.gameObject.GetComponent<ChestHandler>().OpenChest();
                    }
                    else
                    {
                        // Closed selected chest.
                        hit.collider.gameObject.GetComponent<ChestHandler>().ResetChest();
                    }
                }
                else
                {
                    // Return if not applicable.
                    return;
                }
            }

        }
    }
}
