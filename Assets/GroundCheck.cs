using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    public PhysicCharacterController myCharacterController = null;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        myCharacterController.JumpingState = CharacterState.Grounded;
    }
}