using UnityEngine;

public class PlayerAnimationHelper : MonoBehaviour
{


    [SerializeField] Animator playerAnimator;
    private GameObject player;
    [SerializeField] PlayerInputs inputs;
    [SerializeField] PlayerMotor motor;

    int isMovingHash = Animator.StringToHash("isMoving");
    int isGroundedHash = Animator.StringToHash("isGrounded");

    //==================READABLE VALUES=====================) (im not sure how this works, feel free to assign values from here!)
    bool isMoving;
    bool isGrounded;

    //extras
    float movmentSpeed;
    float movmentDirection;
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
        if (isMoving == true)
        {
            playerAnimator.SetBool(isMovingHash, true);
        }
        else
        {
            playerAnimator.SetBool(isMovingHash, false);
        }

        if(isGrounded == true)
        {
            playerAnimator.SetBool(isGroundedHash, true);
        }
        else
        {
            playerAnimator.SetBool(isGroundedHash, false);
        }
    }

    private void Update()
    {
        UpdateValues();
        AnimationMovement();
    }
}