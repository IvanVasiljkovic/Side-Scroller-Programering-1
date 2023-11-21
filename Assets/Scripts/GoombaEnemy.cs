using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoombaEnemy : MonoBehaviour
{
    public int HP = 0;

    public void TakeDamage(int aHPValue)
    {
        HP += aHPValue;
        
        if(HP < 0 )
        {
            GameObject.Destroy(gameObject);
        }
    }
    public Rigidbody2D myRigidbody = null;

    public float MovementSpeedPerSecond = 10.0f;
    public int MovementSign = 1;

    void FixedUpdate()
    {
        Vector3 characterVelocity = myRigidbody.velocity;
        characterVelocity.x = 0;

        characterVelocity += MovementSign * MovementSpeedPerSecond * transform.right.normalized;

        myRigidbody.velocity = characterVelocity;
    }
    
}
