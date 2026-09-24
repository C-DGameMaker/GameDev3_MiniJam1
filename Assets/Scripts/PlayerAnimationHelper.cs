using UnityEngine;

public class PlayerAnimationHelper : MonoBehaviour
{


    [SerializeField] Animator playerAnimator;
    int isMovingHash = Animator.StringToHash("isMoving");
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
        AnimationMovement();
    }
}
