using UnityEngine;

public class PlayerAnimationHelper : MonoBehaviour
{


    [SerializeField] Animator playerAnimator;
    [SerializeField] GameObject player;
    private PlayerInputs inputs;
    private PlayerMotor motor;

    int isMovingHash = Animator.StringToHash("isMoving");

    //==================READABLE VALUES=====================) (im not sure how this works, feel free to assign values from here!)
    bool isMoving;
    bool isGrounded;

    //extras
    float movmentSpeed;
    float movmentDirection;
    //=======================================================

    void Start()
    {
        if(player == null)
        {
            Debug.LogError("No player given to the animation helper!");
            return;
        }

        inputs = player.GetComponent<PlayerInputs>();
    }

    void UpdateValues()
    {
        movmentSpeed = motor.momentum.x;

        if(movmentSpeed <= 0.001f) isMoving = false;
        else isMoving = true;

        movmentDirection = inputs.movmentDirection;
        isGrounded = inputs.grounded;
    }
    void AnimationMovement()
    {
        //if(true)
        //{
        //    playerAnimator.SetBool(isMovingHash, true);
        //}
        //else
        //{
        //    playerAnimator.SetBool(isMovingHash, false);
        //}
    }

    private void Update()
    {
        UpdateValues();
        AnimationMovement();
    }
}
