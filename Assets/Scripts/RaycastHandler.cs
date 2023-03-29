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
                    if (Input.GetButton("Fire1"))
                    {
                        gameManager.PlayGame();
                    }

                }
                else if (hit.collider.gameObject.CompareTag("AddDenominationButton"))
                {
                    if (Input.GetButton("Fire1"))
                    {
                        gameManager.changeDenomination.IncreaseDenomination();
                    }

                }
                else if (hit.collider.gameObject.CompareTag("SubtractDenominationButton"))
                {
                    if (Input.GetButton("Fire1"))
                    {
                        gameManager.changeDenomination.DecreaseDenomination();
                    }

                }
                else if (hit.collider.gameObject.CompareTag("ChestButton"))
                {
                    if (Input.GetButton("Fire1"))
                    {
                        Debug.Log("Success");
                        if (!hit.collider.gameObject.GetComponent<ChestHandler>().chestOpened)
                        {
                            hit.collider.gameObject.GetComponent<ChestHandler>().OpenChest();
                        }
                        else
                        {
                            return;
                        }
                        
                    }

                }
            }

        }
    }
}
