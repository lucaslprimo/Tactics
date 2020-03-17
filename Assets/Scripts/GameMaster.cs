using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    public Unit selectedUnit;

    public int maxPlayers;

    public int playerTurn = 1;

    public GameObject selectedHighlight;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            EndTurn();
        }

        if( selectedUnit == null)
        {
            selectedHighlight.SetActive(false);
        }
        else
        {
            selectedHighlight.SetActive(true);
            selectedHighlight.transform.position = selectedUnit.transform.position;
        }
    }

    public void ResetTiles()
    {
        foreach (Tile tile in FindObjectsOfType<Tile>())
        {
            tile.Reset(); 
        }
    }

    public void EndTurn()
    {
        playerTurn++;
        {
            if (playerTurn > maxPlayers)
            {
                playerTurn = 1;
            }
        }

        ResetUnits();
    }

    public void ResetUnits()
    {
        foreach (Unit unit in FindObjectsOfType<Unit>())
        {
            unit.hasMoved = false;
        }
    }
}
