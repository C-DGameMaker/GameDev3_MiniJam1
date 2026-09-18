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
        
    }
}
