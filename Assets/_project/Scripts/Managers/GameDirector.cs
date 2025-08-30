using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public MapManager mapManager;
    public Player player;
    private void Start()
    {
        mapManager.CreateInitialTiles(30);
    }

    public void Update()
    {
        mapManager.AddTiles(player.transform.position.z);
    }
    
}
