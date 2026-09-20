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
    //
    void Start()
    {
        playerInputs = transform.GetComponent<PlayerInputs>();
    }
    void FixedUpdate()
    {
        //place the position to where the player should be going 

        Vector2 playerTranslatePos = playerInputs.rb.position;
        
        
        
        
        

        if(playerInputs.grounded == false) momentum.y -= gravity * Time.fixedDeltaTime;//gravity
        else 
        {
            //correcting partial tunneling
            float supposedToBeHeight = playerInputs.groundHitHeight + playerInputs.transform.localScale.y/2;
            Debug.Log(playerInputs.groundHitHeight);
            playerTranslatePos.y = supposedToBeHeight;
            //
            momentum.y = Math.Clamp(momentum.y, 0, float.MaxValue);
        }
        if(playerInputs.canJump == true && playerInputs.jumpVal > 0.1) 
        {
            momentum.y += playerInputs.jumpVal * jumpForce * Time.fixedDeltaTime; //jumping
            EventBus.RequestEvent("Jumped", true).Invoke();
        }


        Debug.Log(playerInputs.xMovmentVal + " x " + playerInputs.slopeAnglePlayerUp);
        momentum += (playerInputs.xMovmentVal * -playerInputs.slopeAnglePlayerUp) * Time.fixedDeltaTime;

        
        if(playerInputs.grounded == true) 
        {
            momentum /= gripOnGround;
        }

        //translate them towards it :thumbs_up:


        
        playerTranslatePos += momentum;
        
        
        playerInputs.rb.MovePosition(playerTranslatePos);
        //victory
    }
}
