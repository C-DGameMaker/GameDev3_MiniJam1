using UnityEngine;

public class ForegroundParallax : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float parallaxAmount = 1.5f;

    [SerializeField] private float tileWidth = 20f;

    private Vector3 lastPlayerPosition;

    void Start()
    {
        lastPlayerPosition = player.position;
    }

    void LateUpdate()
    {
        Vector3 movement = player.position - lastPlayerPosition;

        transform.position += new Vector3(movement.x, movement.y * 0.4f, 0);

        foreach (Transform child in transform)
        {
            child.localPosition += Vector3.right * movement.x * (parallaxAmount - 1f);
        }

        foreach (Transform child in transform)
        {
            float x = child.localPosition.x;

            if (x < -tileWidth)
            {
                child.localPosition += Vector3.right * tileWidth * transform.childCount;
            }
            else if (x > tileWidth)
            {
                child.localPosition -= Vector3.right * tileWidth * transform.childCount;
            }
        }

        lastPlayerPosition = player.position;
    }
}
