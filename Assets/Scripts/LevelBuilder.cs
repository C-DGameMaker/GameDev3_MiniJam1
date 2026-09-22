using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class LevelBuilder : MonoBehaviour
{
    private GameObject player = ServiceHubManager.Instance.player;
    

    private void Start()
    {
        EventBus.RequestEvent("ReturnMainMenu", true).ping += ReloadMap;
        InitializeStart();
    }
    private void ReloadMap()
    {
        //delete map

        InitializeStart(); 
    }

    private List<GameObject> maps = new List<GameObject>();
    private GameObject currentPiece;
    private void LoadPiece()
    {
        
    }

    private void InitializeStart()
    {

    }



}
