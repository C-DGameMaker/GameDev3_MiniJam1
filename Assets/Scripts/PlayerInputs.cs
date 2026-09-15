using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class PlayerInputs : MonoBehaviour
{
    //inputs
    public InputActionAsset inputMap;

    private InputAction jumpInput;
    private InputAction xMovmentInput;
    private InputAction crouchInput;
    private InputAction grappleInput;
    //

    //these are what the motor script reads
    public float jumpVal; 
    public float xMovmentVal;
    public float crouchVal;
    public float grappleVal;
    //

    //state values
    public bool grounded; //theres a cooldown on jumping, so these are different!
    public bool canJump;
    public bool grappleHookOut;
    public bool grappleHookAttatched;

    public Vector2 slopeAnglePlayerUp;
    //

    //ground stuff
    public Transform groundCheck;
    //

    //self indntification
    public Rigidbody2D rb;
    //


    void Awake()
    {
        if(inputMap == null) return;
        jumpInput = inputMap.FindAction("Jump");
        xMovmentInput = inputMap.FindAction("Move");
        crouchInput = inputMap.FindAction("Crouch");
        grappleInput = inputMap.FindAction("Attack");
    }
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }


    public void checkGround(float maxSlope)
    {
        RaycastHit2D hit = Physics2D.CircleCast(
            groundCheck.position,
            0.2f,
            Vector2.down,
            0.01f
        );

        if (hit.collider != null)
        {

            Vector2 groundNorm = hit.normal;
            

            float angle = Vector2.Angle(groundNorm, Vector2.up);

            if (angle <= maxSlope)
            {
                Debug.Log("grounded");
                slopeAnglePlayerUp = new Vector2(
                    -groundNorm.y,
                    groundNorm.x
                );
                grounded = true;
            }
            else
            {
                Debug.Log("not grounded");
                slopeAnglePlayerUp = Vector2.up;
                grounded = false;
            }
        }
        else
        {
            Debug.Log("not grounded");
            slopeAnglePlayerUp = Vector2.up;
            grounded = false;
        }

    } 

    void Update()
    {
        checkGround(80f);
    }

}
