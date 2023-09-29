using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;


public enum CharacterState
{
    Grounded = 0,
    Airborne = 1,
    Jumping = 2,
    Total
}

public class Movement : MonoBehaviour
{
    public CharacterState JumpingState = CharacterState.Airborne;

    public float MovementSpeedPerSecond = 10.0f;
    public float GravityPerSecond = 5.0f;
    private float GroundLevel = 0.0f;

    //Jump
    public float JumpSpeedFactor = 3.0f; // How much faster is the jump then the movementspeed?
    public float JumpMaxHeight = 150.0f; // How heigh the character jumps
    public float JumpHeightDelta = 0.0f;

    void Update()
    {
        bool isMoving = false; //tells us that the bitch is moving
        
        if(transform.position.y <= GroundLevel)
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y = GroundLevel;
            transform.position = characterPosition;
            JumpingState = CharacterState.Grounded;
        }

        //for moving ur bitch up
        if (Input.GetKey(KeyCode.W) && JumpingState == CharacterState.Grounded)
        {
            JumpingState = CharacterState.Jumping;
            JumpHeightDelta = 0.0f;
        }
        if(JumpingState == CharacterState.Jumping)
        {
            Vector3 characterPosition = transform.position;
            float totalJumpMovementThisFrame = MovementSpeedPerSecond* JumpSpeedFactor *Time.deltaTime;
            characterPosition.y += totalJumpMovementThisFrame;
            transform.position = characterPosition;
            JumpHeightDelta += totalJumpMovementThisFrame;
            if (JumpHeightDelta >= JumpMaxHeight)
            {
                JumpingState = CharacterState.Airborne;
                JumpHeightDelta = 0.0f;
            }

        }
        //for moving ur bitch left
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x -= MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
            {
                // Flip the character to face left
                Flip(-1f);
            }
        }
        //for moving ur side bitch down
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.y -= MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
        }
        //for moving ur ´side bitch right
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 characterPosition = transform.position;
            characterPosition.x += MovementSpeedPerSecond * Time.deltaTime;
            transform.position = characterPosition;
            {
                // Flip the character to face left
                Flip(1f);
            }
        }

        if (isMoving == false)
        {
            Vector3 gravityPosition = transform.position;
            gravityPosition.y -= GravityPerSecond * Time.deltaTime;
            if (gravityPosition.y < GroundLevel) { gravityPosition.y = GroundLevel; }
            transform.position = gravityPosition;
        }
        void Flip(float direction)
        {
            // Get the current scale
            Vector3 scale = transform.localScale;

            // Flip the character by setting the x-axis scale based on the direction
            scale.x = Mathf.Abs(scale.x) * direction;

            // Apply the new scale
            transform.localScale = scale;
        }
    }
}
