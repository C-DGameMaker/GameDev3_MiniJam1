using UnityEngine;

public class CameraController : MonoBehaviour
{
    //refs
    public GameObject player;

    public GameObject deathWall;
    //

    //
    [SerializeField] float followSpeed;
    [SerializeField] float playerPosOnScreem = 0.4f; //from 0 to 1, 0.5 meaning sitting in the middle, 0 meaning sitting on the far left
    //

    private void Update()
    {
        if (player == null) return;
        Vector2 transformPos = new Vector2(transform.position.x, transform.position.y);
        Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);
        Vector2 deathPosition = new Vector2(deathWall.transform.position.x + 23, deathWall.transform.position.y);

        Vector2 proposedPos = Vector2.Lerp(transformPos, playerPos - new Vector2(7.5f, 0) + new Vector2(15 * playerPosOnScreem, 0), followSpeed);

        if (playerPos.x < deathPosition.x)
        {
            proposedPos.x = Vector2.Lerp(transformPos, deathPosition, followSpeed).x;
        }
        Debug.Log(proposedPos);
        transform.position = new Vector3(proposedPos.x, proposedPos.y, -10);
    }
}
