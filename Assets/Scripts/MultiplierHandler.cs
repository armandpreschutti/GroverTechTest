using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplierHandler : MonoBehaviour
{
    public GameManager gameManager;

    public int[] multiplierOdds= new int[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 3};
    public int[] commonMultiplierValues = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
    public int[] uncommonMultiplierValues = new int[] {12, 16, 24, 32, 48, 64};
    public int[] rareMultiplierValues = new int[] {100, 200, 300, 400, 500};
    public int currentMultiplier;
    public int randomIndex;
    public int multiplierIndex;
    public int commonIndex;
    public int uncommonIndex;
    public int rareIndex;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void PickMultiplier()
    {
        randomIndex = Random.Range(0, multiplierOdds.Length);
        commonIndex = Random.Range(0, commonMultiplierValues.Length);
        uncommonIndex = Random.Range(0, uncommonMultiplierValues.Length);
        rareIndex= Random.Range(0, rareMultiplierValues.Length);
        multiplierIndex = multiplierOdds[randomIndex];

        if (multiplierIndex == 0)
        {
            currentMultiplier = 0;
        }
        else if(multiplierIndex == 1)
        {
            currentMultiplier = commonMultiplierValues[commonIndex];
        }
        else if(multiplierIndex == 2)
        {
            currentMultiplier = uncommonMultiplierValues[uncommonIndex];
        }
        else if(multiplierIndex == 3)
        {
            currentMultiplier = rareMultiplierValues[rareIndex];
        }
    }
}
