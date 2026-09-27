using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 2.0f;
    private Vector3 startPosition;
    private float tileSize;
    void Start()
    {
        startPosition = transform.position;
        tileSize = GetComponent<Renderer>().bounds.size.x;
    }
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSize);
        transform.position = startPosition + Vector3.left * newPosition;
    }
}
