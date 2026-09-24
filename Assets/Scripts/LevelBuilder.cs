
using Unity.Mathematics;
using UnityEngine;


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

    private GameObject player;

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
    private int poolIndexStart = 0;
    private int poolIndexEnd = 1;
    //
    private void Start()
    {
        EventBus.RequestEvent("ReturnMainMenu", true).ping += ReloadMap;
        EventBus.RequestEvent("PiecePassedByWall", true).ping += RePoolPiece;
        InitializeStart();
        player = ServiceHubManager.Instance.player;
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

        int num1;
        int num2;

        for (int i = 0; i < shuffleCount; i++)
        {
            num1 = UnityEngine.Random.Range(0, piecePool.Length - 1);
            num2 = UnityEngine.Random.Range(0, piecePool.Length - 1);

            levelDat temp = piecePool[num1];
            piecePool[num1] = piecePool[num2];
            piecePool[num2] = temp;
        }
        Debug.Log("Done mixing!");
    }
    private bool starting;
    private void PlacePiece()
    {
        int temp = poolIndexEnd;
        poolIndexEnd += 1;
        Debug.Log(poolIndexEnd);

        levelDat obj = piecePool[poolIndexEnd];
        levelDat lastObj;

        if(poolIndexEnd >= piecePool.Length - 1)
        {
            Debug.Log("looping index...");
            poolIndexEnd = -1;
        }

        if (starting)//determening weather to use the starting piece as the piece to place after, or a previous normal piece
        {
            lastObj = startPiece;
            starting = false;
        }
        else
        {
            lastObj = piecePool[temp];
        }
        obj.obj.transform.position = lastObj.endPiece.position - obj.startPiece.localPosition;

        obj.avalabilty = false;
    }
    private void RePoolPiece()
    {
        levelDat obj = piecePool[poolIndexStart];
        if (poolIndexStart >= piecePool.Length - 1)
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

        obj.transform.parent = mapParent.transform;
        obj.transform.position = Vector3.zero;
        starting = true;
        CreateMapPool();

        for (int i = 0; i < 1; i++)
        {
            PlacePiece();
        }
    }

    void Update()
    {
        Debug.Log(math.abs(player.transform.position.x - piecePool[poolIndexEnd - 1].obj.transform.position.x));
        if(math.abs(player.transform.position.x - piecePool[poolIndexEnd - 1].obj.transform.position.x) < 100) 
        {
            PlacePiece();
            Debug.Log("Adding piece");
        }
    }
}
