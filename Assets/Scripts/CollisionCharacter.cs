using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionCharacter : MonoBehaviour
{
    public SpriteRenderer mySpriteRenderer;
    public List<BoxCollider2D> collidersToResize = new List<BoxCollider2D>();

    private void Start()
    {
        // Assuming the script is attached to the same GameObject as the SpriteRenderer
        mySpriteRenderer = GetComponent<SpriteRenderer>();

        // Get all BoxCollider2D components attached to this GameObject
        BoxCollider2D[] colliders = GetComponents<BoxCollider2D>();
        collidersToResize.AddRange(colliders);

        // Set the collider sizes based on the initial sprite
        UpdateColliderSizes();
    }

    // Call this method whenever you change the sprite
    public void ChangeSprite(Sprite newSprite)
    {
        mySpriteRenderer.sprite = newSprite;

        // Update the collider sizes based on the new sprite
        UpdateColliderSizes();
    }

    void UpdateColliderSizes()
    {
        // Iterate through all colliders and update their sizes
        foreach (var collider in collidersToResize)
        {
            if (collider != null)
            {
                float colliderHeight = 1.5f; // Adjust this value based on your requirements
                collider.size = new Vector2(mySpriteRenderer.bounds.size.x, colliderHeight);

                // Move the collider down by 6 pixels
                float yOffset = mySpriteRenderer.bounds.size.y / 2f - colliderHeight / 2f - 6f;
                collider.offset = new Vector2(0f, yOffset);
            }
        }
    }

}