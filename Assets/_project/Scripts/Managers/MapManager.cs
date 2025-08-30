using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private List<GameObject> _tiles = new();
    private int _lastTileIndex;
    public GameObject lightTilePrefab;
    public GameObject darkTilePrefab;
    GameObject newTile;
    GameObject parentObj;

    public void CreateInitialTiles(int number)
    {
        parentObj=new GameObject("Map");

        for (int i = 0; i < number; i++)
        {
           AddTile();
        }
    }

    private void AddTile()
    {
        if (_tiles.Count % 2 == 0)
        {
            newTile=Instantiate(lightTilePrefab,parentObj.transform);
        }
        else
        {
            newTile=Instantiate(darkTilePrefab,parentObj.transform);
        }
            
        newTile.transform.position = new Vector3(0, 0, _lastTileIndex * 5);
        _tiles.Add(newTile);
        _lastTileIndex += 1;
    }
    
    public void AddTiles(float playerPosition)
    {
        if (GetLastTilePosition()-playerPosition < 120)
        {
            UseExistingTile();
        }
    }

    public void UseExistingTile()
    {
        GameObject firstTile = _tiles[0];
        firstTile.transform.position = new Vector3(0, 0, GetLastTilePosition());
        _tiles.RemoveAt(0);
        _lastTileIndex += 1;
        _tiles.Add(firstTile);
    }

    public float GetLastTilePosition()
    {
        return (_lastTileIndex * 5);
    }
}


