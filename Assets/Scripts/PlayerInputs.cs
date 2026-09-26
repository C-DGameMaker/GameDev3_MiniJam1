using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

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
    public bool grounded; 
    public bool onWall;
    public bool canJump;
    public bool grappleHookOut;
    public bool grappleHookAttatched;

    public Vector2 slopeAnglePlayerUp;
    public float groundHitHeight;
    public float wallHitx;
    public float movmentDirection;
    public float jumpCooldown = 1;
    private float jumpCooldownTimer = 0;
    //

    //ground stuff
    public Transform groundCheck;
    //

    //self indntification
    public Rigidbody2D rb;
    //

    void UpdateValues()
    {
        jumpVal = jumpInput.ReadValue<float>();
        xMovmentVal = xMovmentInput.ReadValue<Vector2>().x;
        crouchVal = crouchInput.ReadValue<float>();
        grappleVal = grappleInput.ReadValue<float>();

        jumpCooldownTimer -= Time.fixedDeltaTime;
        if(jumpCooldownTimer < 0 && (grounded || onWall))
        {
            canJump = true;
        }
    }

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

        EventBus.RequestEvent("Jumped", true).ping += OnPlayerJump;
    }

    private void OnPlayerJump()
    {
        canJump = false;
        jumpCooldownTimer = jumpCooldown;
    }


    public void checkGround(float maxSlope)
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(
            groundCheck.position,
            new Vector2(0.5f, 0.1f),
            0,
            Vector2.down,
            0.5f
        );

        grounded = false;

        foreach (RaycastHit2D hit in hits)
        {
            float angle = Vector2.Angle(hit.normal, Vector2.up);

            if (angle <= maxSlope)
            {
                slopeAnglePlayerUp = new Vector2(
                    -hit.normal.y,
                    hit.normal.x
                );

                groundHitHeight = hit.point.y;
                grounded = true;

                break;
            }
        }

        if (!grounded)
        {
            slopeAnglePlayerUp = -Vector2.right;
            groundHitHeight = float.MinValue;
        }
    }
    public void checkWall()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(
            groundCheck.position,
            new Vector2(0.1f, 0.5f),
            0,
            Vector2.right * movmentDirection,
            0.5f
        );
        
        onWall = false;

        foreach (RaycastHit2D hit in hits)
        {
            float angle = Vector2.Angle(hit.normal, Vector2.up);

            if (Mathf.Abs(angle - 90f) < 0.1f)
            {
                wallHitx = hit.point.x;
                onWall = true;
                break;
            }
        }

        if (!onWall)
        {
            wallHitx = -float.MaxValue;
        }
    }

    void FixedUpdate()
    {
        checkWall();
        checkGround(60f);
        UpdateValues();
    }

    


}
