using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class LevelBuilder : MonoBehaviour
{

    private GameObject player = ServiceHubManager.Instance.player;

    //refs
    [SerializeField] GameObject[] mapPiecePrefabs;
    [SerializeField] GameObject startPiece;
    [SerializeField] GameObject mapParent;
    //

    //
    [SerializeField] int shuffleCount;
    //

    //
    private (GameObject obj,Transform startPiece, Transform endPiece, bool avalabilty)[] piecePool;
    private int poolIndexStart;
    private int poolIndexEnd;
    //
    private void Start()
    {
        EventBus.RequestEvent("ReturnMainMenu", true).ping += ReloadMap;
        EventBus.RequestEvent("PiecePassedByWall", true).ping += RePoolPiece;
        InitializeStart();
    }
    private void ReloadMap()
    {
        //delete map

        InitializeStart(); 
    }

    

    private void CreateMapPool()
    {
        piecePool = new (GameObject obj, Transform startPiece, Transform endPiece, bool avalabilty)[mapPiecePrefabs.Length * 20];

        int c = 0;
        foreach (var item in mapPiecePrefabs)
        {
            for (int i = 0; i < 20; i++)
            {
                GameObject obj = Instantiate(item);
                obj.transform.parent = mapParent.transform;
                obj.transform.position = new Vector3(-400, 0, 0);
                piecePool[i + 20 * c] = (obj,obj.transform.Find("Start") , obj.transform.Find("End"), true);
            }
            c += 1;
        }
        for (int i = 0; i < shuffleCount; i++)
        {
            int num1 = Random.Range(0, piecePool.Length);
            int num2 = Random.Range(0, piecePool.Length);

            (GameObject,Transform,Transform,bool) temp = piecePool[num1];
            piecePool[num1] = piecePool[num2];
            piecePool[num2] = temp;
        }
    }
    private void PlacePiece()
    {
        
    }
    private void RePoolPiece()
    {

    }

    private void InitializeStart()
    {
        GameObject obj = Instantiate(startPiece);
        startPiece.transform.parent = mapParent.transform;
        startPiece.transform.position = Vector3.zero;


        for (int i = 0; i < 10; i++)
        {
            PlacePiece();
        }
    }



}
