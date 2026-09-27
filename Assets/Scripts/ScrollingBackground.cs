using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float scrollSpeed = 2.0f;
    private Vector3 startPosition;
    void Start()
    {
        startPosition = transform.position;
    }
    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, 20);
        transform.position = startPosition + Vector3.left * newPosition;
    }
}
