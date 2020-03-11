using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    internal bool selected;
    private GameMaster gm;

    public int tileSpeed;
    internal bool hasMoved = false;

    // Start is called before the first frame update
    void Start()
    {
        gm = FindObjectOfType<GameMaster>();
    }

    private void OnMouseOver()
    {
        Debug.Log("Clicked");
    }


    private void OnMouseDown()
    {
        Debug.Log("Clicked");
        if (selected)
        {
            selected = false;
            gm.selectedUnit = null;
        }
        else
        {
            if(gm.selectedUnit != null)
            {
                gm.selectedUnit.selected = false;
            }

            selected = true;
            gm.selectedUnit = this;
            GetWalkableTiles();
        }
    }

    private void GetWalkableTiles()
    {
        if (hasMoved)
        {
            return;
        }

        Debug.Log("GetWalkableTiles");

        foreach (Tile tile in FindObjectsOfType<Tile>())
        {
            if(Math.Abs(transform.position.x - tile.transform.position.x) + Math.Abs(transform.position.y - tile.transform.position.y) <= tileSpeed)
            {
                if (tile.IsClear())
                {
                    Debug.Log("HighLighing");
                    tile.Highlight();
                }
            }
        }
    }
}
