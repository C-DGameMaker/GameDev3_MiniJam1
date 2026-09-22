using System;
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
    
            momentum.y = Math.Clamp(momentum.y, 0, float.MaxValue);
            momentum += (playerInputs.xMovmentVal * -playerInputs.slopeAnglePlayerUp) * Time.fixedDeltaTime;
        }
        if(playerInputs.canJump == true && playerInputs.jumpVal > 0.1) 
        {
            Debug.Log(playerInputs.movmentDirection);
            momentum.y += playerInputs.jumpVal * jumpForce * Time.fixedDeltaTime; //jumping
            if(playerInputs.onWall) momentum.x += (playerInputs.jumpVal * jumpForce*0.5f) * -playerInputs.movmentDirection * Time.fixedDeltaTime;
            EventBus.RequestEvent("Jumped", true).Invoke();
        }

        //wall physics
        if(playerInputs.onWall)
        {
            if(playerInputs.movmentDirection == 1 )
            {
                playerTranslatePos.x = math.clamp(playerTranslatePos.x, playerInputs.wallHitx - playerInputs.transform.localScale.x/2, float.MinValue);
                momentum.x = math.clamp(momentum.x, 0, float.MinValue);
            }
            else 
            {
                playerTranslatePos.x = math.clamp(playerTranslatePos.x, playerInputs.wallHitx + playerInputs.transform.localScale.x/2 , float.MaxValue);
                momentum.x = math.clamp(momentum.x, 0, float.MaxValue);
            }
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

        if(momentum.x > 0.01f) playerInputs.movmentDirection = 1;
        else if(momentum.x > -0.01f) playerInputs.movmentDirection = -1;
    }
}
