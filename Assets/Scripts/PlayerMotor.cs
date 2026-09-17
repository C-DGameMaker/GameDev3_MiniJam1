using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMotor : MonoBehaviour
{
    private PlayerInputs playerInputs;

    public Vector2 momentum;

    //adjustables
    public float walkSpeed = 1;
    public float jumpForce = 1;
    public float gripOnGround = 1;
    public float gravity = 1;
    //
    void Start()
    {
        playerInputs = transform.GetComponent<PlayerInputs>();
    }
    void FixedUpdate()
    {
        if(playerInputs == null) return;
        // sideways force
        momentum.x += (playerInputs.xMovmentVal * walkSpeed) * Time.deltaTime;
        Debug.Log((playerInputs.xMovmentVal * walkSpeed) * Time.deltaTime);
        //jump
        momentum.y += (playerInputs.jumpVal * jumpForce) * Time.deltaTime;

        //drag
        if(playerInputs.grounded == true) 
        {
            momentum.x -= ( (momentum.x / gripOnGround) * Time.deltaTime);
            //gravity
            momentum.y = math.clamp(momentum.y, 0, float.MaxValue);
        }
        else
        {
            momentum.y -= gravity * Time.deltaTime;
        }

        playerInputs.rb.linearVelocity = momentum;
    }
}
