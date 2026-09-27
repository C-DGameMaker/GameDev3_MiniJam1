using UnityEngine;

public class PlayerAnimationHelper : MonoBehaviour
{


    [SerializeField] Animator playerAnimator;
    private GameObject player;
    [SerializeField] PlayerInputs inputs;
    [SerializeField] PlayerMotor motor;

    int isMovingHash = Animator.StringToHash("isMoving");
    int isGroundedHash = Animator.StringToHash("isGrounded");
    int isLeftHash = Animator.StringToHash("isLeft");
    int isRightHash = Animator.StringToHash("isRight");
    int isJumpingHash = Animator.StringToHash("isJumping");

    //==================READABLE VALUES=====================) (im not sure how this works, feel free to assign values from here!)
    public bool isMoving;
    public bool isGrounded;
    public bool isLeft;
    public bool isRight;
    public bool isJumping;

    //extras
    public float movmentSpeed;
    public float movmentDirection;
    //=======================================================

    void Start()
    {
        player = this.gameObject;
        if (player == null)
        {
            Debug.LogError("No player given to the animation helper!");
            return;
        }
        inputs = player.GetComponent<PlayerInputs>();
        motor = player.GetComponent<PlayerMotor>();
    }

    void UpdateValues()
    {
        movmentSpeed = motor.momentum.x;

        if (movmentSpeed < 0.001f && movmentSpeed > -0.001f)
        {
            isMoving = false;
        }
        else
        {
            isMoving = true;
        }

        

        movmentDirection = inputs.movmentDirection;
        isGrounded = inputs.grounded;
    }
    void AnimationMovement()
    {
        if (movmentDirection < 0)
        {
            isLeft = true;
            isRight = false;
        }
        else if (movmentDirection > 0)
        {
            isLeft = false;
            isRight = true;
        }

        if (inputs.jumpVal > 0 == true)
        {
            isJumping = true;
        }
        else
        {
            isJumping = false;
        }

        if (isJumping == true)
        {
            playerAnimator.SetBool(isJumpingHash, true);
        }
        else
        {
            playerAnimator.SetBool(isJumpingHash, false);
        }

        if (isMoving == true)
        {
            playerAnimator.SetBool(isMovingHash, true);
        }
        else
        {
            playerAnimator.SetBool(isMovingHash, false);
        }

        if (isGrounded == true)
        {
            playerAnimator.SetBool(isGroundedHash, true);
        }
        else
        {
            playerAnimator.SetBool(isGroundedHash, false);
        }

        if (isLeft == true)
        {
            playerAnimator.SetBool(isLeftHash, true);
        }
        else
        {
            playerAnimator.SetBool(isLeftHash, false);
        }

        if (isRight == true)
        {
            playerAnimator.SetBool(isRightHash, true);
        }
        else
        {
            playerAnimator.SetBool(isRightHash, false);
        }
    }

    private void Update()
    {
        UpdateValues();
        AnimationMovement();
    }
}