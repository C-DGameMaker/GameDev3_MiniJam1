using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class levelDat
{
    public levelDat(GameObject objct, Transform strtPiece, Transform ndPiece)
    {
        obj = objct;
        startPiece = strtPiece;
        endPiece = ndPiece;
        avalabilty = true;
    }
    public GameObject obj;
    public Transform startPiece;
    public Transform endPiece;
    public bool avalabilty;
}

public class LevelBuilder : MonoBehaviour
{

    private GameObject player = ServiceHubManager.Instance.player;

    //refs
    [SerializeField] GameObject[] mapPiecePrefabs;
    [SerializeField] GameObject startPiecePrefab;
    [SerializeField] GameObject mapParent;
    //

    //
    [SerializeField] int shuffleCount;
    [SerializeField] int numOfEachPieceInPool;
    //

    //
    private levelDat startPiece;
    private levelDat[] piecePool;
    private int poolIndexStart = 1;
    private int poolIndexEnd = 2;
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
        piecePool = new levelDat[mapPiecePrefabs.Length * numOfEachPieceInPool];

        int c = 0;
        foreach (var item in mapPiecePrefabs)
        {
            for (int i = 0; i < numOfEachPieceInPool; i++)
            {
                GameObject obj = Instantiate(item);
                obj.transform.parent = mapParent.transform;
                obj.transform.position = new Vector3(-400, 0, 0);
                piecePool[i + numOfEachPieceInPool * c] = new (obj,obj.transform.Find("Start") , obj.transform.Find("End"));
            }
            c += 1;
        }
        for (int i = 0; i < shuffleCount; i++)
        {
            int num1 = Random.Range(0, piecePool.Length);
            int num2 = Random.Range(0, piecePool.Length);

            levelDat temp = piecePool[num1];
            piecePool[num1] = piecePool[num2];
            piecePool[num2] = temp;
        }
    }
    private bool starting;
    private void PlacePiece()
    {
        levelDat obj = piecePool[poolIndexEnd];
        levelDat lastObj;
        if(poolIndexEnd >= piecePool.Length)
        {
            poolIndexEnd = -1;
        }
        if (starting)
        {
            lastObj = piecePool[poolIndexEnd + 1];
        }
        else
        {
            lastObj = piecePool[poolIndexEnd + 1];
        }
        obj.obj.transform.position = lastObj.endPiece.position + obj.startPiece.localPosition;
        obj.avalabilty = false;

        poolIndexEnd += 1;
    }
    private void RePoolPiece()
    {
        levelDat obj = piecePool[poolIndexStart];
        if (poolIndexStart >= piecePool.Length)
        {
            poolIndexStart = -1;
        }
        obj.obj.transform.position = new Vector3(-400, 0, 0);
        obj.avalabilty = true;
        poolIndexStart += 1;
    }

    private void InitializeStart()
    {
        GameObject obj = Instantiate(startPiecePrefab);
        startPiece = new levelDat(obj, obj.transform.Find("Start"), obj.transform.Find("End"));
        startPiece.avalabilty = false;

        startPiecePrefab.transform.parent = mapParent.transform;
        startPiecePrefab.transform.position = Vector3.zero;
        starting = true;
        CreateMapPool();

        for (int i = 0; i < 10; i++)
        {
            PlacePiece();
        }
    }
}
