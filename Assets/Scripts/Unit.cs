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
    public float moveSpeed;

    public int playerNumber;

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
            gm.ResetTiles();
        }
        else
        {
            if(playerNumber == gm.playerTurn)
            {
                if (gm.selectedUnit != null)
                {
                    gm.selectedUnit.selected = false;
                }

                selected = true;
                gm.selectedUnit = this;

                gm.ResetTiles();
                GetWalkableTiles();
            }
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

    public void Move(Vector2 position)
    {
        gm.ResetTiles();
        StartCoroutine(StartMovement(position));
    }

    IEnumerator StartMovement(Vector2 position) { 
        while(transform.position.x != position.x)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(position.x, transform.position.y, transform.position.z), moveSpeed * Time.deltaTime) ;
            yield return null;

        }

        while (transform.position.y != position.y)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, position.y, transform.position.z), moveSpeed * Time.deltaTime);
            yield return null;
        }

        hasMoved = true;
    }

}
