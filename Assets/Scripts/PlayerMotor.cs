using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class PlayerMotor : MonoBehaviour
{
    private PlayerInputs playerInputs;

    public Vector2 momentum;

    private float slopeBoost;

    //adjustables
    public float walkSpeed = 1;
    public float jumpForce = 1;
    public float gripOnGround = 1;
    public float gravity = 1;
    public float airMobility = 1;
    //
    void Start()
    {
        playerInputs = transform.GetComponent<PlayerInputs>();
    }
    void FixedUpdate()
    {
        //place the position to where the player should be going 

        Vector2 playerTranslatePos = playerInputs.rb.position;

        if(playerInputs.grounded == false)
        {
            momentum.y -= gravity * Time.fixedDeltaTime;//gravity 

            Vector2 check = (( playerInputs.xMovmentVal * airMobility ) * -playerInputs.slopeAnglePlayerUp) * Time.fixedDeltaTime;
            if(math.abs(check.x + momentum.x) < math.abs(momentum.x)) momentum += check * airMobility; 
        } 
        else 
        {
            //correcting partial tunneling
            float supposedToBeHeight = playerInputs.groundHitHeight + playerInputs.transform.localScale.y/2;
            playerTranslatePos.y = supposedToBeHeight;
            //

            if (math.abs(playerInputs.slopeAnglePlayerUp.x) < 0.99f)
            {
                float boost = math.abs(momentum.y - Math.Clamp(momentum.y, 0, float.MaxValue));
                momentum.y = Math.Clamp(momentum.y, 0, float.MaxValue);
                momentum.x += (boost * playerInputs.slopeAnglePlayerUp.y);
            }
            momentum += (playerInputs.xMovmentVal * -playerInputs.slopeAnglePlayerUp)  * Time.fixedDeltaTime;
        }
        if(playerInputs.canJump == true && playerInputs.jumpVal > 0.1) 
        {
            momentum.y += playerInputs.jumpVal * jumpForce * Time.fixedDeltaTime; //jumping
            
            if(playerInputs.onWall) momentum.x += (playerInputs.jumpVal * jumpForce*0.5f) * -playerInputs.movmentDirection * Time.fixedDeltaTime;
            EventBus.RequestEvent("Jumped", true).Invoke();
        }

        //wall physics
        if(playerInputs.onWall)
        {
            float boost = 0;
            if(playerInputs.movmentDirection == 1 )
            {
                playerTranslatePos.x = math.clamp(playerTranslatePos.x, playerInputs.wallHitx - playerInputs.transform.localScale.x/2, float.MinValue);
                boost = math.abs(momentum.x - math.clamp(momentum.x, float.MinValue, 0));
                momentum.x = math.clamp(momentum.x, float.MinValue, 0);

            }
            else 
            {
                playerTranslatePos.x = math.clamp(playerTranslatePos.x, playerInputs.wallHitx + playerInputs.transform.localScale.x/2 , float.MaxValue);
                boost = math.abs(momentum.x - math.clamp(momentum.x, 0, float.MaxValue));
                momentum.x = math.clamp(momentum.x, 0, float.MaxValue);
            }
            if (momentum.y > 0.01f && momentum.y < 0.1) momentum.y += boost;
        }
        //
        
        if(playerInputs.grounded == true) 
        {
            momentum /= gripOnGround;
        }
        

        //translate them towards it :thumbs_up:

        //
        
        playerTranslatePos += momentum;
        playerInputs.rb.MovePosition(playerTranslatePos);

        if(momentum.x > 0.0001f) playerInputs.movmentDirection = 1;
        else if(momentum.x < -0.0001f) playerInputs.movmentDirection = -1;

    }
}
