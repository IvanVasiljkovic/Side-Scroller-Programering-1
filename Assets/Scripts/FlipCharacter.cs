using UnityEngine;

public class FlipCharacter : MonoBehaviour
{
    private float facingDirection = 1f; // 1 for right, -1 for left

    // Update is called once per frame
    void Update()
    {
        // Check if the 'A' key is pressed
        if (Input.GetKeyDown(KeyCode.A))
        {
            // Flip the character to face left
            SetFacingDirection(-1f);
        }
        // Check if the 'D' key is pressed
        else if (Input.GetKeyDown(KeyCode.D))
        {
            // Flip the character to face right
            SetFacingDirection(1f);
        }
    }

    void SetFacingDirection(float direction)
    {
        // Update the facing direction
        facingDirection = direction;

        // Get the current scale
        Vector3 scale = transform.localScale;

        // Set the x-axis scale based on the facing direction
        scale.x = Mathf.Abs(scale.x) * facingDirection;

        // Apply the new scale
        transform.localScale = scale;
    }
}
