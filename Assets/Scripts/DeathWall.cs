using UnityEngine;

public class DeathWall : MonoBehaviour
{
    [SerializeField] float wallSpeedGainMulti;
    [SerializeField] float initialWallSpeed;
    private Vector3 startPos;

    private BoxCollider2D col;
    private float speed = 5;
    void Start()
    {
        startPos = transform.position;
        EventBus.RequestEvent("StartGameplay", true).ping += StartWallMoving;
        EventBus.RequestEvent("EnteredMainMenu", true).ping += ResetWall;

        EventBus.RequestEvent("EnteredPause", true).ping += pauseWall;
        EventBus.RequestEvent("EnteredGameplay", true).ping += ResumeWall;
        EventBus.RequestEvent("EnteredDeath", true).ping += pauseWall;
    }
    private void StartWallMoving()
    {
        speed = initialWallSpeed;
        movin = true;
    }
    private void ResumeWall()
    {
        movin = true;
    }
    private void pauseWall()
    {
        movin = false;
    }
    private void ResetWall()
    {
        movin = false;
        transform.position = startPos;
    }
    private bool movin;
    private void Update()
    {
        if(movin)
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0 ,0);
            speed += 0.01f * wallSpeedGainMulti * Time.deltaTime;
            Debug.Log(speed);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            EventBus.RequestEvent("PlayerDied", true).Invoke();
        }
    }
}
